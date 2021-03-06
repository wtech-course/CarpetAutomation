"use strict";
var KTUsersAddUser = function () {
    const t = document.getElementById("kt_modal_add_company"),
        e = t.querySelector("#kt_modal_add_company_form"),
        n = new bootstrap.Modal(t);

    var company, number, company_id;
    function convertUTCDateToLocalDate(date) {
        var newDate = new Date(date.getTime() + date.getTimezoneOffset() * 60 * 1000);
        var offset = date.getTimezoneOffset() / 60;
        var hours = date.getHours();
        newDate.setHours(hours - offset);
        return newDate;
    }
    return {
        init: function () {
            (() => {
                var o = FormValidation.formValidation(e, {
                    fields: {
                        company_citizen_name: {
                            validators: {
                                notEmpty: {
                                    message: "Vergi kimlik numaras? zorunludur."
                                }
                            }
                        },
                        company_name: {
                            validators: {
                                notEmpty: {
                                    message: "?irket ismi zorunludur."
                                }
                            }
                        },
                        company_address: {
                            validators: {
                                notEmpty: {
                                    message: "Adres zorunludur."
                                }
                            }
                        }
                    },
                    plugins: {
                        trigger: new FormValidation.plugins.Trigger,
                        bootstrap: new FormValidation.plugins.Bootstrap5({
                            rowSelector: ".fv-row",
                            eleInvalidClass: "",
                            eleValidClass: ""
                        })
                    }
                });
                const i = t.querySelector('[data-kt-users-modal-action="submit"]');
                i.addEventListener("click", (t => {
                    t.preventDefault(),
                        o && o.validate().then((function (t) {
                            console.log("id", company_id), "Valid" == t ? (i.setAttribute("data-kt-indicator", "on"),
                                i.disabled = !0, setTimeout((function () {
                                    i.removeAttribute("data-kt-indicator"),
                                        i.disabled = !1,

                                    number = parseInt($("[name='company_citizen_number']").val());
                                    debugger;                                  
                                    if ($("[name='company_id']").val() == "0") {
                                        company_id = 0;
                                    } else {
                                        company_id = parseInt($("[name='company_id']").val());
                                    }

                                    company = {
                                        id: company_id,
                                        companynumber: number,
                                        companyname: $("[name='company_name']").val(),
                                        address: $("[name='company_address']").val(),
                                        createdate: convertUTCDateToLocalDate(new Date(Date.now()))
                                    };
                                    console.log(JSON.stringify(company));
                                    $.ajax({
                                        type: "POST",
                                        url: "https://localhost:44363/api/company/create",
                                        contentType: "application/json; charset=utf-8",
                                        data: JSON.stringify(company),
                                        dataType: "json",
                                        success: function (data) {
                                            Swal.fire({
                                                text: "Kay?t i?lemi ba?ar?yla ger?ekle?ti.",
                                                icon: "success", buttonsStyling: !1, confirmButtonText: "Ok, devam et!",
                                                customClass: { confirmButton: "btn btn-primary" }
                                            }).then((function (t) { t.isConfirmed && (e.reset(), n.hide(), $("#kt_datatable_example_1").DataTable().ajax.reload()) }))
                                        },
                                        error: function (data) {
                                            Swal.fire({
                                                text: "HATA! Sistem y?neticisi ile ileti?ime ge?iniz!'" + data + "'",
                                                icon: "error", buttonsStyling: !1, confirmButtonText: "Ok, devam et!",
                                                customClass: { confirmButton: "btn btn-primary" }
                                            }).then((function (t) { t.isConfirmed && (e.reset()) }))
                                        }

                                    });
                                }), 2e3)) : Swal.fire({
                                    text: "HATA! Sistem y?neticisi ile ileti?ime ge?iniz! Hen?z post metoduna girilmedi.",
                                    icon: "error",
                                    buttonsStyling: !1,
                                    confirmButtonText: "Ok, got it!",
                                    customClass: {
                                        confirmButton: "btn btn-primary"
                                    }
                                })
                        }))
                })), t.querySelector('[data-kt-users-modal-action="cancel"]').addEventListener("click", (t => {
                    t.preventDefault(), Swal.fire({
                        text: "?ptal etmek istedi?inize emin misiniz?",
                        icon: "warning",
                        showCancelButton: !0,
                        buttonsStyling: !1,
                        confirmButtonText: "Evet, iptal et!",
                        cancelButtonText: "Hay?r",
                        customClass: {
                            confirmButton: "btn btn-primary",
                            cancelButton: "btn btn-active-light"
                        }
                    }).then((function (t) {
                        t.value ? (e.reset(), n.hide()) : "cancel" === t.dismiss && Swal.fire({
                            text: "??lem iptal ediliyor!.",
                            icon: "error",
                            buttonsStyling: !1,
                            confirmButtonText: "Devam et!",
                            customClass: {
                                confirmButton: "btn btn-primary"
                            }
                        })
                    }))
                })), t.querySelector('[data-kt-users-modal-action="close"]').addEventListener("click", (t => {
                    t.preventDefault(), Swal.fire({
                        text: "?ptal etmek istedi?inize emin misiniz?",
                        icon: "warning",
                        showCancelButton: !0,
                        buttonsStyling: !1,
                        confirmButtonText: "Yes, cancel it!",
                        cancelButtonText: "No, return",
                        customClass: {
                            confirmButton: "btn btn-primary",
                            cancelButton: "btn btn-active-light"
                        }
                    }).then((function (t) {
                        t.value ? (e.reset(), n.hide()) : "cancel" === t.dismiss && Swal.fire({
                            text: "??lem iptal ediliyor!.",
                            icon: "error",
                            buttonsStyling: !1,
                            confirmButtonText: "Ok, got it!",
                            customClass: {
                                confirmButton: "btn btn-primary"
                            }
                        })
                    }))
                }))
            })()
        }
    }
}();
KTUtil.onDOMContentLoaded((function () {
    KTUsersAddUser.init()
}));