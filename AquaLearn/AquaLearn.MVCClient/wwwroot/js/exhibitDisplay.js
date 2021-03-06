﻿for (var i = 0; i < fishWaterType.length; i++) {
    if (fishWaterType[i] == 1) {
        if (fishSchooling[i] == "False") {
            fishExDeepNameSingle.push(fishNames[i]);
            fishExDeepDescSingle.push(fishDescriptions[i]);
        }
        else {
            fishExDeepNameSchool.push(fishNames[i]);
            fishExDeepDescSchool.push(fishDescriptions[i]);
        }
    }
    else if (fishWaterType[i] == 2) {
        if (fishSchooling[i] == "False") {
            fishExCoralNameSingle.push(fishNames[i]);
            fishExCoralDescSingle.push(fishDescriptions[i]);
        }
        else {
            fishExCoralNameSchool.push(fishNames[i]);
            fishExCoralDescSchool.push(fishDescriptions[i]);
        }
    }
}

for (var i = 0; i < trashNames.length; i++) {
    if (trashSchooling[i] == "False") {
        fishExPollNameSingle.push(trashNames[i]);
        fishExPollDescSingle.push(trashDescriptions[i]);
    }
    else {
        fishExPollNameSchool.push(trashNames[i]);
        fishExPollDescSchool.push(trashDescriptions[i]);
    }
}


// JS INIT
var vector3Destinations = [];
var vector3Current = [0, 0, 0];
var numFish = getRandomIntRange(3, 7);
var numPlants = getRandomIntRange(5, 10);
var numTrash = getRandomIntRange(5, 10);

var fishes = [];
var school = [];
var currFishSingle = [];
var currFishSchool = [];

var trash = [];
var trashSchool = [];
var currTrashSingle = [];
var currTrashSchool = [];

var fishesMove = [];
var trashMove = [];

var plants = [];
var clicked = false;

var schooling = getRandomIntRange(0, 4);
var direction = ['l', 'r'];

// Move Speed of fish
var MoveSpeed = 1;
var canvasHeight = 480;
var canvasWidth = 720;
var boundary = 100;

// Canvas init
var last = new Date();
var schoolingVector3 = [];
var exhibitType = "_DeepOcean";
var objectsAtLocation = [];
var currObjLocation = [];

init();
setInterval(function () {
    if (runExhibit) {
        update();
    }
}, 17);

function init() {
    // Init Fish
    for (var i = 0; i <= numFish; i++) {
        schooling = getRandomIntRange(0, 4);
        // add fish to fishes
        if (schooling == 0) {
            vector3Current = setRndVector3();
            fishes.push(vector3Current);

            currFishSingle.push(GetFishSingleInEx());
        }
        else {
            if (schoolingVector3 == null
                || schoolingVector3.length == 0) {
                vector3Current = setRndVector3();
                schoolingVector3 = vector3Current;
                currFishSchool.push(GetFishSchoolInEx());
            }
            else {
                vector3Current = schoolingVector3;
                currFishSchool.push(currFishSchool[0]);
            }
            school.push(vector3Current);
        }

        fishesMove.push(direction[0]);
        vector3Destinations.push([0, 0, 0]);
        schoolingVector3 = [];
    }

    // Init Trash
    for (var i = 0; i <= numTrash; i++) {
        schooling = getRandomIntRange(0, 4);
        // add trash to trash
        if (schooling == 0) {
            vector3Current = setRndVector3();
            trash.push(vector3Current);

            currTrashSingle.push(GetFishSingleInEx());
        }
        else {
            if (schoolingVector3 == null
                || schoolingVector3.length == 0) {
                vector3Current = setRndVector3();
                schoolingVector3 = vector3Current;
                currTrashSchool.push(GetFishSchoolInEx());
            }
            else {
                vector3Current = schoolingVector3;
                currTrashSchool.push(currTrashSchool[0]);
            }
            trashSchool.push(vector3Current);
        }

        trashMove.push(direction[0]);
        vector3Destinations.push([0, 0, 0]);
        schoolingVector3 = [];
    }

    //// Init Plants
    //for (var i = 0; i <= numPlants; i++) {
    //    plants.push(setPlantDestination());
    //}
}

// UPDATE

function update() {
    clear();
    place();
    checkClick();
    currObjLocation = [];
}

function clear() {
    ctx.clearRect(0, 0, 720, 480);
}

function checkClick() {
    var obj = "";
    if (clicked) {
        obj = getAtLocation(mouseX, mouseY);
        clicked = false;
    }

    var nameDesc = document.getElementById("nameOfObj");
    var descDesc = document.getElementById("descOfObj");
    if (obj != "") {
        nameDesc.innerText = obj;
        descDesc.innerText = getDescription(obj);
    }
}

function place() {
    drawBackground();

    // Single Fish
    if (exhibitType == "_CoralReef"
        || exhibitType == "_DeepOcean") {
        for (var i = 0; i < fishes.length; i++) {
            // currFish setup [name, startx, startyl, startyr, width, height]
            var currFish = getFishSprite(currFishSingle[i], true);
            fishes[i] = swim(currFish, i, fishes[i][0], fishes[i][1], fishes[i][2]);
            var yPos;
            if (fishesMove[i] == 'l') {
                yPos = currFish[2];
            }
            else {
                yPos = currFish[3];
            }

            drawImage(fishSpriteSheet, currFish[1], yPos, currFish[4], currFish[5], fishes[i][0], fishes[i][1], currFish[4], currFish[5]);
            setAtLocation(currFish[0], fishes[i][0], fishes[i][1], currFish[4], currFish[5]);
        }

        // School Fish

        for (var i = 0; i < school.length; i++) {
            var destPos = i + fishes.length;
            // currFish setup [name, startx, startyl, startyr, width, height]
            var currFish = getFishSprite(currFishSchool[i], false);
            school[i] = swimTogether(currFish, destPos, school[i][0], school[i][1], school[i][2]);

            var yPos;
            if (fishesMove[i + fishes.length] == 'l') {
                yPos = currFish[2];
            }
            else {
                yPos = currFish[3];
            }

            drawImage(fishSpriteSheet, currFish[1], yPos, currFish[4], currFish[5], school[i][0], school[i][1], currFish[4], currFish[5]);
            setAtLocation(currFish[0], school[i][0], school[i][1], currFish[4], currFish[5]);
        }
    }
    else {
        //Trash

        for (var i = 0; i < trash.length; i++) {
            // currTrash setup [name, startx, startyl, startyr, width, height]
            var currTrash = getFishSprite(currTrashSingle[i], true);
            trash[i] = swim(currTrash, i, trash[i][0], trash[i][1], trash[i][2]);
            var yPos;
            if (trashMove[i] == 'l') {
                yPos = currTrash[2];
            }
            else {
                yPos = currTrash[3];
            }

            drawImage(fishSpriteSheet, currTrash[1], yPos, currTrash[4], currTrash[5], trash[i][0], trash[i][1], currTrash[4], currTrash[5]);
            setAtLocation(currTrash[0], trashSchool[i][0], trashSchool[i][1], currTrash[4], currTrash[5]);
        }

        for (var i = 0; i < trashSchool.length; i++) {
            var destPos = i + trash.length;
            // currTrash setup [name, startx, startyl, startyr, width, height]
            var currTrash = getFishSprite(currTrashSchool[i], false);
            trashSchool[i] = swimTogether(currTrash, destPos, trashSchool[i][0], trashSchool[i][1], trashSchool[i][2]);

            var yPos;
            if (trashMove[i + trash.length] == 'l') {
                yPos = currTrash[2];
            }
            else {
                yPos = currTrash[3];
            }

            drawImage(fishSpriteSheet, currTrash[1], yPos, currTrash[4], currTrash[5], trashSchool[i][0], trashSchool[i][1], currTrash[4], currTrash[5]);
            setAtLocation(currTrash[0], trashSchool[i][0], trashSchool[i][1], currTrash[4], currTrash[5]);
        }
    }
    //// Plants

    //for (var i = 0; i < plants.length; i++) {
    //    ctx.fillStyle = plantColor;
    //    drawRectangles(plants[i][0], plants[i][1], plants[i][2]);
    //}        
}

function placeQuizPicture(name) {
    drawBackground();

    // currFish setup [name, startx, startyl, startyr, width, height]
    var currFish = getFishSprite(name, true);
    drawImage(fishSpriteSheet, currFish[1], currFish[2], currFish[4], currFish[5], 100, 100, currFish[4], currFish[5]);
}

function refresh() {
    fishes = [];
    school = [];
    plants = [];
    trash = [];
    trashSchool = [];

    currFishSingle = [];
    currFishSchool = [];
    currTrashSingle = [];
    currTrashSchool = [];
    schoolingVector3 = [];
    objectsAtLocation = [];

    numFish = getRandomIntRange(3, 7);
    numPlants = getRandomIntRange(5, 10);
    numTrash = getRandomIntRange(5, 10);
    init();
}

// DRAW

function drawImage(img, startX, startY, sw, sh, dx, dy, width, height) {
    ctx.drawImage(img, startX, startY, sw, sh, dx, dy, width, height);
}

function drawBackground() {
    // Create gradient
    var grd = ctx.createLinearGradient(0, 0, 0, 300);
    grd.addColorStop(0, "blue");
    grd.addColorStop(1, "darkblue");

    // Fill with gradient
    ctx.fillStyle = grd;
    ctx.fillRect(0, 0, canvasWidth, canvasHeight);

    var grd2 = ctx.createLinearGradient(0, 0, 0, 50);
    grd2.addColorStop(0, "yellow");
    grd2.addColorStop(1, "tan");

    // Fill with gradient
    ctx.fillStyle = grd2;
    ctx.fillRect(0, canvasHeight - canvasHeight * 0.1, canvasWidth, 50);
}

function checkDestination(name, xd, yd, zd, xc, yc, zc, schooling) {
    var vector3Dest = [xd, yd, zd];
    var vector3Curr = [xc, yc, zc];
    if (vector3Dest[0] == 0
        && vector3Dest[1] == 0
        && vector3Dest[2] == 0) {
        vector3Dest = setDestination(name, schooling);
    }

    if (checkVertical(name)) {
        if (vector3Curr[0] == vector3Dest[0]
            && vector3Curr[1] == vector3Dest[1]) {
            vector3Dest = setDestination(name, schooling);
        }
    }
    else {
        if (vector3Curr[0] == vector3Dest[0]) {
            vector3Dest = setDestination(name, schooling);
        }
    }

    return vector3Dest;
}

function checkVertical(name) {
    var needVertical = false;
    if (name == "Tuna"
        || name == "Clownfish"
        || name == "Jellyfish"
        || name == "Seal"
        || name == "Walrus"
        || name == "Dolphin"
        || name == "Shark"
        || name == "Whale"
        || name == "Swordfish"
        || name == "Manatee"
        || name == "Squid"
        || name == "Plastic Bags"
        || name == "Straws") {
        needVertical = true;
    }
    else {
        needVertical = false;
    }

    return needVertical;
}

function changeExhibit(partialViewToInsert) {
    exhibitType = partialViewToInsert;
    refresh();
}

// *******************
// GET AND SET
// *******************

// GET

function getSwimType(name, i, x, y, z) {
    var vector3 = [x, y, z];
    if (name == "Shark"
        || name == "Whale"
        || name == "Swordfish"
        || name == "Manatee"
        || name == "Squid"
        || name == "Plastic Bags"
        || name == "Straws") {
        // swim
        vector3 = swimBasic(i, x, y, z);
    }
    else if (name == "Tuna"
        || name == "Clownfish"
        || name == "Jellyfish"
        || name == "Seal"
        || name == "Walrus"
        || name == "Dolphin") {
        // swim together
        vector3 = swimBasic(i, x, y, z);
    }
    else if (name == "Stingray"
        || name == "Octopus"
        || name == "Seahorse") {
        // swim floor
        if (y < canvasHeight * 0.8
            || y > canvasHeight * 0.9) {
            y = getRandomIntRange(canvasHeight * 0.8, canvasHeight * 0.9);
        }
        vector3 = swimFloor(i, x, y, z);
    }
    else {
        // Swim None
        if (y < canvasHeight * 0.8) {
            y = canvasHeight * 0.8;
        }
        vector3 = swimNone(i, x, y, z);
    }

    return vector3;
}

function GetFishSingleInEx() {
    var fishSingle = 0;
    switch (exhibitType) {
        case "_CoralReef":
            fishSingle = fishExCoralNameSingle.length;
            break;
        case "_DeepOcean":
            fishSingle = fishExDeepNameSingle.length;
            break;
        default:
            fishSingle = fishExPollNameSingle.length;
            break;
    }

    return getRandomIntRange(0, fishSingle);
}

function GetFishSchoolInEx() {
    var fishSchool = 0;
    switch (exhibitType) {
        case "_CoralReef":
            fishSchool = fishExCoralNameSchool.length;
            break;
        case "_DeepOcean":
            fishSchool = fishExDeepNameSchool.length;
            break;
        default:
            fishSchool = fishExPollNameSchool.length;
            break;
    }

    return getRandomIntRange(0, fishSchool);
}

function getFishSprite(i, single) {
    var name;
    if (typeof i === 'string') {
        name = i;
    }
    else {
        name = getName(i, single);
    }

    var sprite;
    switch (name) {
        // [name, startx, startyl, startyr, width, height]
        case "Shark":
            sprite = ["Shark", 250, 250, 0, 250, 150];
            break;
        case "Swordfish":
            sprite = ["Swordfish", 700, 250, 0, 250, 100];
            break;
        case "Tuna":
            sprite = ["Tuna", 500, 350, 100, 150, 50];
            break;
        case "Clownfish":
            sprite = ["Clownfish", 850, 350, 100, 100, 50];
            break;
        case "Stingray":
            sprite = ["Stingray", 350, 400, 150, 100, 100];
            break;
        case "Jellyfish":
            sprite = ["Jellyfish", 450, 400, 150, 100, 100];
            break;
        case "Eel":
            sprite = ["Eel", 950, 350, 100, 100, 50];
            break;
        case "Seahorse":
            sprite = ["Seahorse", 950, 400, 150, 100, 100];
            break;
        case "Whale":
            sprite = ["Whale", 0, 250, 0, 250, 150];
            break;
        case "Seal":
            sprite = ["Seal", 650, 350, 100, 200, 50];
            break;
        case "Walrus":
            sprite = ["Walrus", 500, 250, 0, 200, 100];
            break;
        case "Dolphin":
            sprite = ["Dolphin", 950, 250, 0, 250, 100];
            break;
        case "Manatee":
            sprite = ["Manatee", 150, 400, 150, 200, 100];
            break;
        case "Octopus":
            sprite = ["Octopus", 0, 400, 150, 150, 100];
            break;
        case "Squid":
            sprite = ["Squid", 850, 400, 150, 100, 100];
            break;
        case "Oyster":
            sprite = ["Oyster", 550, 400, 150, 100, 100];
            break;
        case "Beverage Cans":
            sprite = ["Beverage Cans", 1050, 350, 100, 50, 50];
            break;
        case "Plastic Bottles":
            sprite = ["Plastic Bottles", 750, 400, 150, 100, 100];
            break;
        case "Plastic Bags":
            sprite = ["Plastic Bags", 650, 400, 150, 100, 100];
            break;
        case "Straws":
            sprite = ["Straws", 1100, 350, 100, 50, 50];
            break;
        default:
            sprite = ["Clownfish", 850, 350, 100, 100, 50];
            break;
    }

    return sprite;
}

function getRandomIntRange(min, max) {
    return Math.floor((Math.random() * (max - min)) + min);
}

function getName(i, single) {
    var name;
    switch (exhibitType) {
        case "_CoralReef":
            if (single) {
                name = fishExCoralNameSingle[i];
            }
            else {
                name = fishExCoralNameSchool[i];
            }
            break;
        case "_DeepOcean":
            if (single) {
                name = fishExDeepNameSingle[i];
            }
            else {
                name = fishExDeepNameSchool[i];
            }
            break;
        default:
            if (single) {
                name = fishExPollNameSingle[i];
            }
            else {
                name = fishExPollNameSchool[i];
            }
            break;
    }

    return name;
}

function getAtLocation(mouseX, mouseY) {
    // name, startX, startY, width, height
    var obj = "";
    for (var i = 0; i < currObjLocation.length; i++) {
        if (mouseX >= currObjLocation[i][1]
            && mouseX <= currObjLocation[i][1] + currObjLocation[i][3]
            && mouseY >= currObjLocation[i][2]
            && mouseY <= currObjLocation[i][2] + currObjLocation[i][4]) {
            return currObjLocation[i][0];
        }
    }
    return obj;
}

function getDescription(name) {
    var desc;
    for (var i = 0; i < fishNames.length; i++) {
        if (fishNames[i] == name) {
            desc = fishDescriptions[i];
        }
    }

    for (var i = 0; i < trashNames.length; i++) {
        if (trashNames[i] == name) {
            desc = trashDescriptions[i];
        }
    }

    for (var i = 0; i < plantNames.length; i++) {
        if (plantNames[i] == name) {
            desc = plantDescriptions[i];
        }
    }

    return desc;
}

// SET

function setAtLocation(name, startX, startY, width, height) {
    currObjLocation.push([name, startX, startY, width, height]);
}

function setDestination(name, schooling) {
    vector3Dest = [0, 0, 0];
    var screenWidthMax;
    var screenHeightMax;
    var screenDepthMax = 15;
    var screenWidthMin;
    var screenHeightMin;
    var screenDepthMin = 0;

    if (!schooling) {
        screenWidthMax = 720 - name[4];
        screenHeightMax = 480 - name[5];
        screenWidthMin = 0;
        screenHeightMin = 0;
    }
    else {
        screenWidthMax = vector3Destinations[fishes.length][0] + boundary;
        screenHeightMax = vector3Destinations[fishes.length][1] + boundary;
        screenWidthMin = vector3Destinations[fishes.length][0] - boundary;
        screenHeightMin = vector3Destinations[fishes.length][1] - boundary;
    }
    vector3Dest[0] = getRandomIntRange(screenWidthMin, screenWidthMax);
    vector3Dest[1] = getRandomIntRange(screenHeightMin, screenHeightMax);
    // Determine which layer the fish will swim on
    vector3Dest[2] = getRandomIntRange(screenDepthMin, screenDepthMax);

    return vector3Dest;
}

function setPlantDestination() {
    vector3Dest = [0, 0, 0];
    var screenWidthMax;
    var screenHeightMax;
    var screenDepthMax = 15;
    var screenWidthMin;
    var screenHeightMin;
    var screenDepthMin = 0;

    screenWidthMax = canvasWidth;
    screenHeightMax = canvasHeight;
    screenWidthMin = 0;
    screenHeightMin = canvasHeight * 0.8;

    vector3Dest[0] = getRandomIntRange(screenWidthMin, screenWidthMax);
    vector3Dest[1] = getRandomIntRange(screenHeightMin, screenHeightMax);
    // Determine which layer the fish will swim on
    vector3Dest[2] = getRandomIntRange(screenDepthMin, screenDepthMax);

    return vector3Dest;
}

function setRndVector3() {
    var vector3 = [getRandomIntRange(0, canvasWidth - (canvasWidth * 0.1)), getRandomIntRange(0, canvasHeight - (canvasHeight * 0.2)), getRandomIntRange(-15, -1)];

    return vector3;
}

function setVector3Current(x, y, z) {
    vector3Current[0] = x;
    vector3Current[1] = y;
    vector3Current[2] = z;
}

function setToFloor(y) {
    if (y < (canvasHeight - (canvasHeight * 0.9))) {
        y = getRandomIntRange(canvasHeight * 0.9, canvasHeight);
    }

    return y;
}

// *******************
// MOVEMENT & PLACEMENT
// *******************

// Applies to Shark, Whale, Swordfish, Manatees, squid
function swim(name, i, x, y, z) {
    vector3Current = [x, y, z];
    //Check if at/near destination before moving
    vector3Destinations[i] = checkDestination(name, vector3Destinations[i][0], vector3Destinations[i][1], vector3Destinations[i][2], vector3Current[0], vector3Current[1], vector3Current[2])
    vector3Current = getSwimType(name[0], i, vector3Current[0], vector3Current[1], vector3Current[2]);

    return vector3Current;
}

// Applies to Tuna, Clownfish, jellyfish, seals, walruses, dolphins
function swimTogether(name, i, x, y, z) {
    vector3Current = [x, y, z];
    //Check if at/near destination before moving if lead fish
    if (i == fishes.length) {
        vector3Destinations[i] = checkDestination(name, vector3Destinations[i][0], vector3Destinations[i][1], vector3Destinations[i][2], vector3Current[0], vector3Current[1], vector3Current[2], false);
    }
    else {
        vector3Destinations[i] = checkDestination(name, vector3Destinations[i][0], vector3Destinations[i][1], vector3Destinations[i][2], vector3Current[0], vector3Current[1], vector3Current[2], true);
    }
    vector3Current = getSwimType(name[0], i, vector3Current[0], vector3Current[1], vector3Current[2]);

    return vector3Current;
}

function swimBasic(i, x, y, z) {
    vector3Current = [x, y, z];

    // Swim right
    vector3Current = swimRight(i, vector3Current[0], vector3Current[1], vector3Current[2]);

    // Swim left
    vector3Current = swimLeft(i, vector3Current[0], vector3Current[1], vector3Current[2]);

    // Swim down
    vector3Current = swimDown(i, vector3Current[0], vector3Current[1], vector3Current[2]);

    // Swim up
    vector3Current = swimUp(i, vector3Current[0], vector3Current[1], vector3Current[2]);

    return vector3Current;
}

// Applies to stingray, octopus, seahorse
function swimFloor(i, x, y, z) {
    vector3Current = [x, y, z];
    vector3Current[1] = setToFloor(vector3Current[1]);

    // Swim right
    vector3Current = swimRight(i, vector3Current[0], vector3Current[1], vector3Current[2]);

    // Swim left
    vector3Current = swimLeft(i, vector3Current[0], vector3Current[1], vector3Current[2]);

    return vector3Current;
}

// Applies to Eels, oysters
function swimNone(i, x, y, z) {
    vector3Current = [x, y, z];

    vector3Current[1] = setToFloor(vector3Current[1]);

    return vector3Current;
}

function swimLeft(i, x, y, z) {
    vector3Current = [x, y, z];
    if (vector3Current[0] > vector3Destinations[i][0]) {
        vector3Current[0] -= MoveSpeed;
        fishesMove[i] = direction[0];
    }
    return vector3Current;
}

function swimRight(i, x, y, z) {
    vector3Current = [x, y, z];
    if (vector3Current[0] < vector3Destinations[i][0]) {
        vector3Current[0] += MoveSpeed;
        fishesMove[i] = direction[1];
    }
    return vector3Current;
}

function swimUp(i, x, y, z) {
    vector3Current = [x, y, z];
    if (vector3Current[1] > vector3Destinations[i][1]) {
        vector3Current[1] -= MoveSpeed;
    }
    return vector3Current;
}

function swimDown(i, x, y, z) {
    vector3Current = [x, y, z];
    if (vector3Current[1] < vector3Destinations[i][1]) {
        vector3Current[1] += MoveSpeed;
    }
    return vector3Current;
}
