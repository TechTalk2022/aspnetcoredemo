//custom validation rule
$.validator.addMethod("customemail",
    function (value, element) {
        return /^\w+([-+.']\w+)*@@\w+([-.]\w+)*\.\w+([-.]\w+)*$/.test(value);
    },
    "Please enter a valid email address."
);
$("#frmStudentDetails").validate({
    rules: {
        "FirstName": {
            required: true,
            maxlength: 20
        },
        "MidleName": {
            required: true,
            maxlength: 20
        },
        "LastName": {
            required: true,
            maxlength: 20
        },
        "Department": {
            required: true
        },
        "PhoneNumber": {
            required: true,
            minlength: 10,
            maxlength: 10
        },
        "Email": {
            required: {
                depends: function () {
                    $(this).val($.trim($(this).val()));
                    return true;
                }
            },
            customemail: true,
            maxlength: 100
        },
        "fav_language": {
            required: true
        },
        "vehicle1": {
            required: true
        }
    },
    messages: {
        "FirstName": {
            required: "Please, enter a first name"
        },
        "MidleName": {
            required: "Please, enter a middle name"

        },
        "LastName": {
            required: "Please, enter a last Name"
        },
        "Department": {
            required: "Please, select a department"
        },
        "PhoneNumber": {
            required: "Please, select a phone number"
        },
        "Email": {
            required: "Please, select a email"
        },
        "fav_language": {
            required: "Please, select a fav_language"
        },
        "vehicle1": {
            required: "Please, select a vehicle type"
        }
    },
    submitHandler: function (form) { // for demo
        //alert('valid form submitted'); // for demo
        return false; // for demo
    }
});