﻿var vector3Destinations = [];
var vector3Current = [0, 0, 0];
var fishes = [];
var school = [];
var plants = [];
var schooling = false;

// Move Speed of fish
var MoveSpeed = 1;
var boundary = 100;
// Canvas init
var last = new Date();
var myGameArea = draw();
var ctx = getContext();

// FPS set to ~60fps
setInterval(function () { update(); }, 17);

function update() {
    clear();
    place();
}

function draw() {
    var myGameArea = document.getElementById("myCanvas");
    return myGameArea;
}

function getContext() {
    if (myGameArea.getContext) {
        ctx = myGameArea.getContext('2d');
    }
    return ctx;
}

function setVector3Current(x, y, z) {
    vector3Current[0] = x;
    vector3Current[1] = y;
    vector3Current[2] = z;
}

function drawSquares(x, y, z) {
    ctx.fillRect(x, y, 50, 50);
}

function drawRectangles(x, y, z) {
    ctx.fillRect(x, y, 50, 50);
}

function clear() {
    ctx.clearRect(0, 0, 720, 480);
}

function place() {
    for (var i = 0; i < fishes.length; i++) {
        fishes[i] = swim(i, fishes[i][0], fishes[i][1], fishes[i][2]);
        ctx.fillStyle = "blue";
        drawSquares(fishes[i][0], fishes[i][1], fishes[i][2]);
    }

    for (var i = 0; i < school.length; i++) {
        destPos = i + fishes.length;
        school[i] = swimTogether(destPos, school[i][0], school[i][1], school[i][2]);
        ctx.fillStyle = "black";
        drawSquares(school[i][0], school[i][1], school[i][2]);
    }

    for (var i = 0; i < plants.length; i++) {
        ctx.fillStyle = "green";
        drawRectangles(plants[i][0], plants[i][1], plants[i][2]);
    }
}

function swim(i, x, y, z) {
    vector3Current = [x, y, z];
    //Check if at/near destination before moving
    vector3Destinations[i] = checkDestination(vector3Destinations[i][0], vector3Destinations[i][1], vector3Destinations[i][2], vector3Current[0], vector3Current[1], vector3Current[2])
    vector3Current = basicMove(i, vector3Destinations[i][0], vector3Destinations[i][1], vector3Destinations[i][2], vector3Current[0], vector3Current[1], vector3Current[2]);

    return vector3Current;
}

function swimTogether(i, x, y, z) {
    vector3Current = [x, y, z];
    //Check if at/near destination before moving if lead fish
    if (i == fishes.length) {
        vector3Destinations[i] = checkDestination(vector3Destinations[i][0], vector3Destinations[i][1], vector3Destinations[i][2], vector3Current[0], vector3Current[1], vector3Current[2], false);
    }
    else {
        vector3Destinations[i] = checkDestination(vector3Destinations[i][0], vector3Destinations[i][1], vector3Destinations[i][2], vector3Current[0], vector3Current[1], vector3Current[2], true);
    }
    vector3Current = schoolMove(i, vector3Destinations[i][0], vector3Destinations[i][1], vector3Destinations[i][2], vector3Current[0], vector3Current[1], vector3Current[2]);

    return vector3Current;
}

function setDestination(schooling) {
    vector3Dest = [0, 0, 0];
    var screenWidthMax;
    var screenHeightMax;
    var screenDepthMax = 15;
    var screenWidthMin;
    var screenHeightMin;
    var screenDepthMin = 0;

    if (!schooling) {
        screenWidthMax = 720;
        screenHeightMax = 480;
        screenWidthMin = 0;
        screenHeightMin = 0;
    }
    else {
        screenWidthMax = vector3Destinations[fishes.length][0] + boundary;
        screenHeightMax = vector3Destinations[fishes.length][1] + boundary;
        screenWidthMin = vector3Destinations[fishes.length][0] - boundary;
        screenHeightMin = vector3Destinations[fishes.length][1] - boundary;
    }

    // TODO: get canvas width to be cap
    vector3Dest[0] = getRandomIntRange(screenWidthMin, screenWidthMax);
    // TODO: get canvas height to be cap
    vector3Dest[1] = getRandomIntRange(screenHeightMin, screenHeightMax);
    // Determine which layer the fish will swim on
    vector3Dest[2] = getRandomIntRange(screenDepthMin, screenDepthMax);

    return vector3Dest;
}

function getRandomIntRange(min, max) {
    return Math.floor((Math.random() * (max - min)) + min);
}

function checkDestination(xd, yd, zd, xc, yc, zc, schooling) {
    var vector3Dest = [xd, yd, zd];
    var vector3Curr = [xc, yc, zc];
    if (vector3Dest[0] == 0
        && vector3Dest[1] == 0
        && vector3Dest[2] == 0) {
        vector3Dest = setDestination(schooling);
    }

    if (vector3Curr[0] == vector3Dest[0]
        && vector3Curr[1] == vector3Dest[1]) {
        vector3Dest = setDestination(schooling);
    }

    return vector3Dest;
}

function basicMove(i, xd, yd, zd, xc, yc, zc) {
    vector3Current = [xc, yc, zc];


    // Swim right
    if (vector3Current[0] < vector3Destinations[i][0]) {
        vector3Current[0] += MoveSpeed;
    }

    // Swim left
    if (vector3Current[0] > vector3Destinations[i][0]) {
        vector3Current[0] -= MoveSpeed;
    }

    // Swim down
    if (vector3Current[1] < vector3Destinations[i][1]) {
        vector3Current[1] += MoveSpeed;
    }

    // Swim up
    if (vector3Current[1] > vector3Destinations[i][1]) {
        vector3Current[1] -= MoveSpeed;
    }

    return vector3Current;
}

function schoolMove(i, xd, yd, zd, xc, yc, zc) {
    vector3Current = [xc, yc, zc];
    // Swim right
    if (vector3Current[0] < vector3Destinations[i][0]) {
        vector3Current[0] += MoveSpeed;
    }

    // Swim left
    if (vector3Current[0] > vector3Destinations[i][0]) {
        vector3Current[0] -= MoveSpeed;
    }

    // Swim down
    if (vector3Current[1] < vector3Destinations[i][1]) {
        vector3Current[1] += MoveSpeed;
    }

    // Swim up
    if (vector3Current[1] > vector3Destinations[i][1]) {
        vector3Current[1] -= MoveSpeed;
    }

    return vector3Current;
}