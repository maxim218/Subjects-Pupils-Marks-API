"use strict";

const request = require('request');

const NULL = null;

function sendPost(url, body, callback) {
    console.log("--------------------");
    console.log("POST");
    console.log("Url: " + url);
    console.log("Body: " + body);

	const headersObj = {};
	headersObj["Cache-Control"] = "no-cache, no-store, must-revalidate";
	headersObj["Content-Type"] = "application/json";

    request.post({
        url: url,
        body: body,
        headers: headersObj,
    }, function (error, response, body) {
        const result = body.toString();
        console.log("Result: " + result);
        callback(result.toString());
    });
}

function sendGet(url, callback) {
    console.log("--------------------");
    console.log("GET");
    console.log("Url: " + url);

	const headersObj = {};
	headersObj["Cache-Control"] = "no-cache, no-store, must-revalidate";
	headersObj["Content-Type"] = "text/plain";

    request.get({
        url: url,
        body: NULL,
        headers: headersObj,
    }, function (error, response, body) {
        const result = body.toString();
        console.log("Result: " + result);
        callback(result.toString());
    });
}

function promiseSendPost(url, body) {
    return new Promise(resolve => {
        sendPost(url, body, text => {
            resolve(text);
        })
    });
}

function promiseSendGet(url) {
    return new Promise(resolve => {
        sendGet(url, text => {
            resolve(text);
        });
    });
}

const maxK = 6;
const maxI = 200;

async function main() {
    await promiseSendPost("http://localhost:5007/database/clear", JSON.stringify({}));

    for(let k = 1; k <= maxK; k++) {
        const arrNicknames = [];
        const arrSubjects = [];

        // pupils
        for(let i = 1; i <= maxI; i++) {
            const nickname = "pupil_" + i + "_" + k;
            arrNicknames.push(nickname);
            const age = i + 25;
            await promiseSendPost("http://localhost:5007/pupils/add", JSON.stringify({nickname, age}));
        }
        await promiseSendGet("http://localhost:5007/pupils/get/all?sort=0");
        await promiseSendGet("http://localhost:5007/pupils/get/all?sort=1");

        // subjects
        for(let i = 1; i <= maxI; i++) {
            const subject = "subject_" + i + "_" + k;
            arrSubjects.push(subject);
            const description = "description_" + i + "_" + k;
            await promiseSendPost("http://localhost:5007/subjects/add", JSON.stringify({ subject, description }));
        }
        await promiseSendGet("http://localhost:5007/subjects/get/all?sort=0");
        await promiseSendGet("http://localhost:5007/subjects/get/all?sort=1");

        // marks
        for(let i = 0; i < arrNicknames.length; i++) {
            const nickname = arrNicknames[i];
            const subject = arrSubjects[i];
            const mark = (10 + i) % 5 + 1;
            await promiseSendPost("http://localhost:5007/marks/add", JSON.stringify({nickname, subject, mark}));
        }
    }
}

main();