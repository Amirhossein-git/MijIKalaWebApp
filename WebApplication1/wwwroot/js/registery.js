
function checkFormSignIn() {
    let firstNameField = document.forms["registery-form"]["UserName"];
    let lastNameField = document.forms["registery-form"]["PassWord"];
    if (firstNameField.value.length >= 1 &&
        lastNameField.value.length >= 1)
        return true;
    firstNameField.classList.add("validated");
    lastNameField.classList.add("validated");
    return false;
}

function checkFormSignUp() {

    let userNameField = document.forms["registery-form"]["UserName"];
    let passWordField = document.forms["registery-form"]["PassWord"];
    let nameField = document.forms["registery-form"]["Name"];
    let familyNameField = document.forms["registery-form"]["FamilyName"];
    let adressField = document.forms["registery-form"]["Adress"];
    let homePhoneNumberField = document.forms["registery-form"]["HomePhoneNumber"];
    let mobilePhoneNumberField = document.forms["registery-form"]["MobilePhoneNumber"];
    let postCodeField = document.forms["registery-form"]["PostCode"];
    let emailField = document.forms["registery-form"]["Email"];

    if (nameField.value.length >= 3 &&
        userNameField.value.length >= 3 &&
        familyNameField.value.length >= 2 &&
        passWordField.value.length >= 7 &&
        postCodeField.value != null &&
        adressField.value != null &&
        homePhoneNumberField.value != null &&
        mobilePhoneNumberField.value != null)
        return true;
    nameField.classList.add("validated");
    familyNameField.classList.add("validated");
    userNameField.classList.add("validated");
    passWordField.classList.add("validated");
    postCodeField.classList.add("validated");
    mobilePhoneNumberField.classList.add("validated");
    homePhoneNumberField.classList.add("validated");
    emailField.classList.add("validated");
    adressField.classList.add("validated");
    return false;
}
