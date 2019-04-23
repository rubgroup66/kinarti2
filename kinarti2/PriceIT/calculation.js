var myBoxes;
var myMaterials;
var myFacades;
var myHandles, handlesCost;
var myHinges, hingesCost1, hingesCost2;
var constants;
var params;
var height, width, depth;
var myIronWorks, ironWorksCost1, ironWorksCost2;
var numberOfDistancedInternalDrawer;
var facadeColorWorkCoefficient, facadeFRNWorkCoefficient;
var plateWorkCostForSquareMeter;



$(document).ready(function () {
    ajaxCall("GET", "../api/materials", "", successGetMaterials, error); //get all materials from DB
    ajaxCall("GET", "../api/facades", "", successGetFacades, error);
    ajaxCall("GET", "../api/boxes", "", successGetBoxes, error);
    ajaxCall("GET", "../api/handles", "", successGetHandles, error);
    ajaxCall("GET", "../api/hinges", "", successGetHinges, error);
    ajaxCall("GET", "../api/constants", "", successGetConstants, error);
    ajaxCall("GET", "../api/ironWorks", "", successGetIronWorks, error);
    $("#pForm").submit(f1);
});

function error(err) { // this function is activated in case of a failure
    swal("Error: " + err);
}

function successGetMaterials(materialsdata) {// this function is activated in case of a success
    myMaterials = materialsdata;
    //myMaterials = (JSON.stringify(materialsdata));    
    for (var i = 0; i < materialsdata.length; i++) {
        $('#boxMaterial').append('<option value="' + materialsdata[i].ID + '" >' + materialsdata[i].Name + '</option>');
    }
    console.log("myMaterials" + " " + myMaterials);
}

function successGetFacades(facadesdata) {// this function is activated in case of a success
    console.log("facadesdata" + " " + facadesdata);
    //facades = (JSON.stringify(facadesdata));
    myFacades = facadesdata;
    for (var i = 0; i < facadesdata.length; i++) {
        $('#facade').append('<option value="' + facadesdata[i].ID + '" >' + facadesdata[i].Type + '</option>');
    }
    for (i = 0; i < facadesdata.length; i++) {
        $('#extraWallType').append('<option value="' + facadesdata[i].ID + '" >' + facadesdata[i].Type + '</option>');
    }
    console.log("myFacades" + " " + myFacades);
}

function successGetBoxes(boxesdata) {// this function is activated in case of a success
    // console.log(boxesdata);
    // boxes = (JSON.stringify(boxesdata));
    myBoxes = boxesdata;
    for (var i = 0; i < boxesdata.length; i++) {
        $('#boxMeasures').append('<option value="' + boxesdata[i].ID + '" >' + boxesdata[i].Height + 'X' + boxesdata[i].Width + 'X' + boxesdata[i].Depth + '</option>');
    }
}

function successGetHandles(handlesdata) {// this function is activated in case of a success
    //console.log(handlesdata);
    //handles = (JSON.stringify(handlesdata));
    myHandles = handlesdata;
    for (var i = 0; i < handlesdata.length; i++) {
        $('#handlesType').append('<option value="' + handlesdata[i].ID + '" >' + handlesdata[i].Type + '</option>');
    }
}
function successGetHinges(hingesdata) {// this function is activated in case of a success
    //console.log(hingesdata);
    //hinges=(JSON.stringify(hingesdata));
    myHinges = hingesdata;
    for (var i = 0; i < hingesdata.length; i++) {
        $('#hingesType1').append('<option value="' + hingesdata[i].ID + '" >' + hingesdata[i].Type + '</option>');
        $('#hingesType2').append('<option value="' + hingesdata[i].ID + '" >' + hingesdata[i].Type + '</option>');
    }
}

function successGetIronWorks(ironworksdata) {// this function is activated in case of a success
    //ironworks = (JSON.stringify(ironworksdata));
    myIronWorks = ironworksdata;
    for (var i = 0; i < ironworksdata.length; i++) {
        $('#ironWorksType1').append('<option value="' + ironworksdata[i].ID + '" >' + ironworksdata[i].Type + '</option>');
        $('#ironWorksType2').append('<option value="' + ironworksdata[i].ID + '" >' + ironworksdata[i].Type + '</option>');
    }
}

function successGetConstants(constantsdata) {// this function is activated in case of a success
    constants = constantsdata;
    console.log(constants);
    //constants = (JSON.stringify(constantsdata));
}

function success(data) {
    swal("Added Successfuly!", "Good luck in finding a partner", "success");
}
function f1() {
    calculateItem();
    return false; // the return false will prevent the form from being submitted
    // hence the page will not reload
}

var materialCoefficient;
var totalSum = 0;

function calculateItem() {
    collectChoices();

    boxSquareMeter = (2 * height * depth + 2 * width * depth + height * width) / 10000;
    
    var boxCost = basicMaterialCoefficient * boxSquareMeter * materialCoefficient + workCost * boxSquareMeter + lacquerWorkCost * boxSquareMeter;
    
    withPartitions = params.partitionsQuantity * (workCost * height * depth * 2 + lacquerWorkCost * height * depth * 2);

    withShelves = (workCost * depth * width + lacquerWorkCost * height * width) * params.shelvesQuantity / (params.partitionsQuantity + 1);
    
    plateSquareMeter = drawerCoefficientCost * (depth - 5) * (plateThickness * + width * plateThickness * drawerCoefficientCost + (depth - 5) * width) / 10000;

    withboxWoodDrawers = (plateSquareMeter * basicMaterialCoefficient * materialWoodDrawersCoefficient + plateSquareMeter * lacquerWorkCost + woodRailsCost + woodBoxDrawerWorkCost) * params.boxWoodDrawersQuantity;
    //debugger;

    withInternalLegraBoxDrawers = (LegraBoxDrawerWork + LegraboxInternalRailsCost) * params.internalLegraBoxDrawersQuantity;
    withExternalLegraBoxDrawers = (LegraBoxDrawerWork + LegraboxExternalRailsCost) * params.externalLegraBoxDrawersQuantity

    ScalaSquareMeter = ((depth - 5) * width + drawerCoefficientCost * width) / 1000;

    withInternalScalaBoxDrawers = (ScalaSquareMeter * ScalaCoefficient * ScalaDrawerWork + ScalaInternalRailsCost) * params.internalScalaBoxDrawersQuantity;
    withExternalScalaBoxDrawers = (ScalaSquareMeter * ScalaCoefficient * ScalaDrawerWork + ScalaExternalRailsCost) * params.externalScalaBoxDrawersQuantity;
 
    withDistancedInternalDrawer = (woodBoxDrawerWorkCost * numberOfDistancedInternalDrawer + (depth - 7) * lacquerWorkCost) /10000;  //not final

    facadeWorkCost = 200;   //not final
    withFacade = height * width / 10000 * materialWorkCost + workCostForSquareMeter+(height*width/1000 *2*  facadeColorWorkCoefficient* isColor +  height*width/1000* 2 * facadeFRNWorkCoefficient + 12* (height*2+ width*2)*(isColor+1)); // kantim
    // basicMaterialCoefficient + boxWorkCost * height * depth + (height * width / 10000 * facadeColorWorkCoefficient + height * width / 10000 * 100) + facadeFRNWorkCoefficient * height * width / 10000 + height * width / 10000 * 100 + 12 * (height * 2 + width * 2)); //need to update according to material type params.extraWallTypeID)

    withExtraWall = params.extraWallQuantity * (height * depth * basicMaterialCoefficient + boxWorkCost * height * depth + (height * width / 10000 * facadeColorWorkCoefficient + height * width / 10000 * 100) + facadeFRNWorkCoefficient * height * width / 10000 + height * width / 10000 * 100 + 12 * (height * 2 + width * 2)); //need to update according to material type params.extraWallTypeID)



    withHinges1 = hingesCost1 * params.hingesQuantity1;
    withHinges2 = hingesCost2 * params.hingesQuantity2;
       
    withHandles = handlesCost * params.handlesQuantity;

    withIronWorks1 = ironWorksCost1 * params.ironWorksQuantity1;
    withIronWorks2 = ironWorksCost2 * params.ironWorksQuantity2;

    totalSum = boxCost + withPartitions
        + withShelves + withboxWoodDrawers
        + withInternalLegraBoxDrawers + withExternalLegraBoxDrawers
        + withInternalScalaBoxDrawers + withExternalScalaBoxDrawers
        + withHinges1 + withHinges2 + withHandles
        + withIronWorks1 + withIronWorks2
        + withDistancedInternalDrawer + withExtraWall + withFacade;
    //totalSum = boxCost + withPartitions + withShelves + withboxWoodDrawers; //checking..


    console.log("withExtraWall +" + withExtraWall);
    console.log("withDistancedInternalDrawer +" + withDistancedInternalDrawer);
    console.log("withPartitions +" + withPartitions);
    console.log("withShelves +" + withShelves);
    console.log("withboxWoodDrawers +" + withboxWoodDrawers);
    console.log("withInternalLegraBoxDrawers +" + withInternalLegraBoxDrawers);
    console.log("withExternalLegraBoxDrawers +" + withExternalLegraBoxDrawers);
    console.log("withInternalScalaBoxDrawers +" + withInternalScalaBoxDrawers);
    console.log("withExternalScalaBoxDrawers +" + withExternalScalaBoxDrawers);
    console.log("withHinges1 +" + withHinges1);
    console.log("withHinges2 +" + withHinges2);
    console.log("withHandles +" + withHandles);

    console.log(totalSum);

    return false; // the return false will prevent the form from being submitted
    // hence the page will not reload
}

function collectChoices() {
    params = {
        boxID: $("#boxMeasures").val(),
        materialID: $("#boxMaterial").val(),
        partitionsQuantity: $("#partitions").val(),
        shelvesQuantity: $("#shelves").val(),
        boxWoodDrawersQuantity: $("#boxWoodDrawers").val(),
        internalLegraBoxDrawersQuantity: $("#internalLegraBoxDrawers").val(),
        externalLegraBoxDrawersQuantity: $("#externalLegraBoxDrawers").val(),
        internalScalaBoxDrawersQuantity: $("#internalScalaBoxDrawers").val(),
        externalScalaBoxDrawersQuantity: $("#externalScalaBoxDrawers").val(),
        facadeID: $("#facade").val(),
        hingesType1ID: $("#hingesType1").val(),
        hingesQuantity1: $("#hingesQuantity1").val(),
        hingesType2ID: $("#hingesType2").val(),
        hingesQuantity2: $("#hingesQuantity2").val(),
        extraWallTypeID: $("#extraWallType").val(),
        extraWallQuantity: $("#extraWallQuantity").val(),
        handlesTypeID: $("#handlesType").val(),
        handlesQuantity: $("#handlesQuantity").val(),
        ironWorksType1ID: $("#ironWorksType1").val(),
        ironWorksQuantity1: $("#ironWorksQuantity1").val(),
        ironWorksType2ID: $("#ironWorksType2").val(),
        ironWorksQuantity2: $("#ironWorksQuantity2").val()
    };

    for (i = 0; i < myBoxes.length; i++) {
        if (myBoxes[i].ID.toString() === params.boxID) { // this is the handles cost
            height = myBoxes[i].Height;
            width = myBoxes[i].Width;
            depth = myBoxes[i].Depth;
        }
    }
    //console.log("myBoxes: ", myBoxes);

    workCost = constants[0].Cost;
    lacquerWorkCost = constants[1].Cost;
    basicMaterialCoefficient = constants[2].Cost;

    for (i = 0; i < myMaterials.length; i++) {
        if (myMaterials[i].ID.toString() === params.materialID) { // this is the specific material cost
            materialCoefficient = myMaterials[i].Coefficient;
            //console.log("myMaterials: ", myMaterials);
        }
    }

    woodRailsCost = constants[5].Cost;

    for (i = 0; i < myHinges.length; i++) {
        if (myHinges[i].ID.toString() === params.hingesType1ID) { // this is hinges 1 cost
            hingesCost1 = myHinges[i].Cost;
        }
        if (myHinges[i].ID.toString() === params.hingesType2ID) { // this is hinges 2 cost
            hingesCost2 = myHinges[i].Cost;
        }
    }

    for (i = 0; i < myHandles.length; i++) {
        if (myHandles[i].ID.toString() === params.handlesTypeID) { // this is the handles cost
            handlesCost = myHandles[i].Cost;
        }
    }

    for (i = 0; i < myIronWorks.length; i++) {
        if (myIronWorks[i].ID.toString() === params.ironWorksType1ID) { // this is hinges 1 cost
            ironWorksCost1 = myIronWorks[i].Cost;
        }
        if (myIronWorks[i].ID.toString() === params.ironWorksType2ID) { // this is hinges 2 cost
            ironWorksCost2 = myIronWorks[i].Cost;
        }

        LegraBoxDrawerWork = constants[7].Cost;
        ScalaDrawerWork = constants[8].Cost;
        drawerCoefficientCost = constants[3].Cost;
        plateThickness = constants[4].Cost;
        ScalaCoefficient = constants[9].Cost;
        LegraboxInternalRailsCost = constants[10].Cost;
        LegraboxExternalRailsCost = constants[12].Cost;
        ScalaInternalRailsCost = constants[11].Cost;
        ScalaExternalRailsCost = constants[13].Cost;
        woodBoxDrawerWorkCost = constants[6].Cost;

        facadeColorWorkCoefficient = 200;
        facadeFRNWorkCoefficient = 280;

        plateWorkCostForSquareMeter = 25;

        materialWorkCost = 47;

        workCostForSquareMeter = plateWorkCostForSquareMeter / height * width;

        materialWoodDrawersCoefficient = 2.64;
        //materialWoodDrawersCoefficient = params.materialWoodDrawersCoefficient;
    }

    //// this should be used when the active value is changed
    function buttonEvents() {
        $(document).on("click", ".isDistanced", function () {
            var isDistanced = $(this).is(':checked') ? 1 : 0; // replace with true value
            console.log("change made");
        });

        numberOfDistancedInternalDrawer = height >= 70 ? 2 : 1;// if number height is less than 70 there is only one distanced drawer

        for (var i = 0; i < myFacades.length; i++) {
            if (myFacades[i].ID.toString() === params.facadeID) { // this is the handles cost
                facadesCost = myFacades[i].Cost;
            }
        }
    }
}