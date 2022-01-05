"use strict";
var KTUsersAddUser = function () {
    const t = document.getElementById("kt_modal_add_company"),
        e = t.querySelector("#kt_modal_add_company_form"),
        n = new bootstrap.Modal(t);
      
    var company, number, s;
    function formatDate() {
        debugger;
        var today = new Date();
        var date = today.getDate(); + '-' + (today.getMonth() + 1) + '-' + today.getFullYear();
        var time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
        var dateTime = date + ' ' + time;
        return dateTime;
    }
    return {
        init: function () {
            (() => {
                var o = FormValidation.formValidation(e, {
                    fields: {
                        company_citizen_name: {
                            validators: {
                                notEmpty: {
                                    message: "Vergi kimlik numarasý zorunludur."
                                }
                            }
                        },
                        company_name: {
                            validators: {
                                notEmpty: {
                                    message: "Þirket ismi zorunludur."
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
                            console.log("validated!"), "Valid" == t ? (i.setAttribute("data-kt-indicator", "on"),
                                i.disabled = !0, setTimeout((function () {
                                    i.removeAttribute("data-kt-indicator"),
                                        i.disabled = !1,
                                        number = parseInt($("[name='company_citizen_number']").val());
                                    company = {
                                        companynumber: number,
                                        companyname: $("[name='company_name']").val(),
                                        address: $("[name='company_address']").val(),
                                        creatdate: formatDate()
                                    };
                                    console.log("data", JSON.stringify(company));
                                    $.ajax({
                                        type: "POST",
                                        url: "https://localhost:44363/api/company/create",
                                        contentType: "application/json; charset=utf-8",
                                        data: JSON.stringify(company),
                                        dataType: "json",
                                        success: function (data) {
                                            Swal.fire({
                                                text: "Kayýt iþlemi baþarýyla gerçekleþti.",
                                                icon: "success", buttonsStyling: !1, confirmButtonText: "Ok, devam et!",
                                                customClass: { confirmButton: "btn btn-primary" }
                                            }).then((function (t) { t.isConfirmed && (e.reset(), n.hide(), $("#kt_datatable_example_1").DataTable().ajax.reload()) }))
                                        },
                                        error: function (data) {
                                            Swal.fire({
                                                text: "HATA! Sistem yöneticisi ile iletiþime geçiniz!'" + data + "'",
                                                icon: "error", buttonsStyling: !1, confirmButtonText: "Ok, devam et!",
                                                customClass: { confirmButton: "btn btn-primary" }
                                            }).then((function (t) { t.isConfirmed && (e.reset()) }))
                                        }

                                    });
                                }), 2e3)) : Swal.fire({
                                    text: "HATA! Sistem yöneticisi ile iletiþime geçiniz! Henüz post metoduna girilmedi.",
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
                        text: "Ýptal etmek istediðinize emin misiniz?",
                        icon: "warning",
                        showCancelButton: !0,
                        buttonsStyling: !1,
                        confirmButtonText: "Evet, iptal et!",
                        cancelButtonText: "Hayýr",
                        customClass: {
                            confirmButton: "btn btn-primary",
                            cancelButton: "btn btn-active-light"
                        }
                    }).then((function (t) {
                        t.value ? (e.reset(), n.hide()) : "cancel" === t.dismiss && Swal.fire({
                            text: "Ýþlem iptal ediliyor!.",
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
                        text: "Ýptal etmek istediðinize emin misiniz?",
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
                            text: "Ýþlem iptal ediliyor!.",
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