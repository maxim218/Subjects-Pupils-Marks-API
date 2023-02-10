using Microsoft.EntityFrameworkCore;
using SubjectsPupilsMarks.Scripts.Answers;
using SubjectsPupilsMarks.Scripts.ApplicationInfo;
using SubjectsPupilsMarks.Scripts.Database;
using SubjectsPupilsMarks.Scripts.Database.Models;
using SubjectsPupilsMarks.Scripts.Logic;
using SubjectsPupilsMarks.Scripts.NotFound;

var builder = WebApplication.CreateBuilder(args);
const string connection = "Host=localhost;Port=5432;Database=s_p_m_base;Username=postgres;Password=12345";
builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connection));
var app = builder.Build();

app.Map("/marks/get", appBuilder => {
    appBuilder.Run(async context => {
        string nickname = context.Request.Query["nickname"]!;
        string subject = context.Request.Query["subject"]!;
        string sortType = context.Request.Query["sort"]!;
        ApplicationContext db = context.RequestServices.GetService<ApplicationContext>()!;
        List<MarkModel> list = FinderMarks.FindMarks(db, nickname, subject, sortType);
        await context.Response.WriteAsJsonAsync(list);
    });
});

app.Map("/marks/add", appBuilder => {
    appBuilder.Run(async context => {
        var postBody = await context.Request.ReadFromJsonAsync<MarkModel>();
        if (null == postBody) throw new Exception("Not correct POST Body");
        string nickname = postBody.Nickname;
        string subject = postBody.Subject;
        int mark = postBody.Mark;
        ApplicationContext db = context.RequestServices.GetService<ApplicationContext>()!;
        PupilModel? pupilObj = FinderPupil.Find(db, nickname);
        SubjectModel? subjectObj = FinderSubject.Find(db, subject);
        if (null == pupilObj || null == subjectObj) {
            AnswerResult obj = new AnswerResult { Result = "BAD_NICKNAME_OR_SUBJECT" };
            await context.Response.WriteAsJsonAsync(obj);
        } else {
            CreatorMark.Create(db, nickname, subject, mark);
            AnswerResult obj = new AnswerResult { Result = "OK" };
            await context.Response.WriteAsJsonAsync(obj);
        }
    });
});

app.Map("/pupils/get/all", appBuilder => {
    appBuilder.Run(async context => {
        string sortType = context.Request.Query["sort"]!;
        ApplicationContext db = context.RequestServices.GetService<ApplicationContext>()!;
        List<PupilModel> list = FinderPupil.FindAll(db, sortType);
        await context.Response.WriteAsJsonAsync(list);
    });
});

app.Map("/pupils/add", appBuilder => {
    appBuilder.Run(async context => {
        var postBody = await context.Request.ReadFromJsonAsync<PupilModel>();
        if (null == postBody) throw new Exception("Not correct POST Body");
        ApplicationContext db = context.RequestServices.GetService<ApplicationContext>()!;
        string nickname = postBody.Nickname;
        PupilModel ? pupilModel = FinderPupil.Find(db, nickname);
        if (null == pupilModel) {
            CreatorPupil.Create(db, postBody.Nickname, postBody.Age);
            AnswerResult obj = new AnswerResult { Result = "OK" };
            await context.Response.WriteAsJsonAsync(obj);
        } else {
            await context.Response.WriteAsJsonAsync(pupilModel);
        }
    });
});

app.Map("/pupils/get/count", appBuilder => {
    appBuilder.Run(async context => {
        ApplicationContext db = context.RequestServices.GetService<ApplicationContext>()!;
        int count = CounterPupils.GetCount(db);
        AnswerCount obj = new AnswerCount {
            Count = count
        };
        await context.Response.WriteAsJsonAsync(obj);
    });
});

app.Map("/subjects/get/all", appBuilder => {
    appBuilder.Run(async context => {
        string sortType = context.Request.Query["sort"]!;
        ApplicationContext db = context.RequestServices.GetService<ApplicationContext>()!;
        List<SubjectModel> list = FinderSubject.FindAll(db, sortType);
        await context.Response.WriteAsJsonAsync(list);
    });
});

app.Map("/subjects/get", appBuilder => {
    appBuilder.Run(async context => {
        string subject = context.Request.Query["subject"]!;
        ApplicationContext db = context.RequestServices.GetService<ApplicationContext>()!;
        SubjectModel ? subjectModel = FinderSubject.Find(db, subject);
        if (null == subjectModel) {
            AnswerResult obj = new AnswerResult { Result = "NOT_FOUND" };
            await context.Response.WriteAsJsonAsync(obj);
        } else {
            await context.Response.WriteAsJsonAsync(subjectModel);
        }
    });
});

app.Map("/subjects/add", appBuilder => {
    appBuilder.Run(async context => {
        var postBody = await context.Request.ReadFromJsonAsync<SubjectModel>();
        if (null == postBody) throw new Exception("Not correct POST Body");
        ApplicationContext db = context.RequestServices.GetService<ApplicationContext>()!;
        SubjectModel ? subjectModel = FinderSubject.Find(db, postBody.Subject);
        if (null == subjectModel) {
            CreatorSubject.Create(db, postBody.Subject, postBody.Description);
            AnswerResult obj = new AnswerResult { Result = "OK" };
            await context.Response.WriteAsJsonAsync(obj);
        } else {
            await context.Response.WriteAsJsonAsync(subjectModel);
        }
    });
});

app.Map("/database/clear", appBuilder => {
    appBuilder.Run(async context => {
        ApplicationContext db = context.RequestServices.GetService<ApplicationContext>()!;
        CleanerDatabase.Clear(db);
        AnswerResult obj = new AnswerResult { Result = "OK" };
        await context.Response.WriteAsJsonAsync(obj);
    });
});

app.Map("/application/info", appBuilder => {
    appBuilder.Run(async context => {
        Information obj = new Information(app);
        await context.Response.WriteAsJsonAsync(obj);
    });
});

app.Run(async context => {
    MessageNotFound obj = new MessageNotFound();
    context.Response.StatusCode = 404;
    await context.Response.WriteAsJsonAsync(obj);
});

app.Run();
