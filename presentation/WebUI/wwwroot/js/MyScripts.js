
        $('#add_product_form').on('submit', (e) => {
        e.preventDefault();

    var formData = new FormData(e.currentTarget);

    $.ajax({
        url: e.currentTarget.action,
    data: formData,
    method: 'POST',
    processData: false,
    contentType: false
            }).done(function (response) {
        sessionStorage.setItem("productId", response);
    $('input[name="createProductItemViewModel.ProductId"]').val(sessionStorage.getItem("productId"));
            }).fail(function () {
        alert("error");
            });
        })

    var variants;
        $.get("/Admin/ProductItem/GetVariants", (data) => {
        variants = data;
    val1 = val1.replace('#options#', listOptoins(data.colors));
    val2 = val2.replace('#options#', listOptoins(data.sizes));
    val3 = val3.replace('#options#', listOptoins(data.materials));
        })

        $('#addItem').on('click', (e) => {
        e.preventDefault();
            //$.get("/Admin/ProductItem/AddProductItem?ui-culture=az-AZ", {productid: 'fdfdfdf' }, (data) => showModal(data))
    let modal = document.getElementById('productItemModal');
    showModal(modal);
        })

        const showModal = (modal) => {
        $('#popup-overlay').css({
            'visibility': 'visible'
        })
             
             modal.style.position = 'relative';
    modal.style.top = '50%';
    modal.style.left = '50%';
    modal.style.width = '1300px';
    modal.style.minHeight = '800px';
    modal.style.maxHeight = '500px';
    modal.style.overflow = 'auto';
    modal.style.transform = 'translate(-50%, -50%)';
    $(modal).css({'border': '1px solid black', 'z-index': '9999' });
    $('#popup-overlay').css({'opacity': '100%' });


            // let hasColorVariant = $('.variants-container label:contains("Color 1")')[0] != undefined;
            // let hasSizeVariant = $('.variants-container label:contains("Size 1")')[0] != undefined;
            // let hasMaterialVariant = $('.variants-container label:contains("Material 1")')[0] != undefined;


            // const row = $('.body-row');

            //$(`<th class='${e.target.value}'>${e.target.value}</th>`).insertBefore('#1st');

            //const th = document.createElement('th');
            //th.classList.add(`${e.target.value}`);

            //let fc = row.find('.1st');

            //fc[0].parentElement.insertBefore(th, fc[0]);


            //$(modal).find('.t-body').append(row.clone());
 

        }

        var listOptoins = (list) => {
        let row;
    for (let i = 0; i < list.length; i++) {
        row += `\r\n<option>` + list[i] + `</option>`
    }
    return row;
            }


    var val1 = `<div class="bs-example">
        <select class="js-example-basic-single w-100" name="ProductItem.Color">
            #options#
        </select>
    </div>`;
    var val2 = `<div class="bs-example">
        <select class="js-example-basic-single w-100" name="ProductItem.Size">
            #options#
        </select>
    </div>`;
    var val3 = `<div class="bs-example">
        <select class="js-example-basic-single w-100" name="ProductItem.Material">
            #options#
        </select>
    </div>`;

        // var val1 = `<div class="row mt-1 align-items-center variant-values">
        //                    <label class="col-sm-3 col-form-label form-label-title">#value-here#</label>
        //                    <div class="col-sm-9">
        //                        <div class="bs-example">
        //                            <select class="js-example-basic-single w-100" name="state">
        //                                #options#
        //                            </select>
        //                        </div>
        //                    </div>
        //                </div>`;
        // var val2 = `<div class="row mt-1 align-items-center variant-values">
        //         <label class="col-sm-3 col-form-label form-label-title">#value-here#</label>
        //         <div class="col-sm-9">
        //             <div class="bs-example">
        //                 <select class="js-example-basic-single w-100" name="state">
        //                     #options#
        //                 </select>
        //             </div>
        //         </div>
        //     </div>`;
        // var val3 = `<div class="row mt-1 align-items-center variant-values">
        //             <label class="col-sm-3 col-form-label form-label-title">#value-here#</label>
        //             <div class="col-sm-9">
        //                 <div class="bs-example">
        //                     <select class="js-example-basic-single w-100" name="state">
        //                         #options#
        //                     </select>
        //                 </div>
        //             </div>
        //         </div>`;

        // let ic = 0;
        // let is = 0;
        // let im = 0;
        // $('.add-option').on('click', (e) => {
        //     e.preventDefault();
        //     var text = $('.variant-selector')[0].options[$('.variant-selector')[0].selectedIndex].text;
        //     const template = document.createElement('template');

        //     switch (text.toLowerCase()) {
        //         case 'color':
        //             ic++;
        //             template.innerHTML = val1.replace('#value-here#', text + ' ' + ic);
        //             const resultc = template.content.children;

        //             $('.variant-values label:contains("Color"):last').parent().after($(resultc));
        //             break;
        //         case 'size':
        //             is++;
        //             template.innerHTML = val2.replace('#value-here#', text + ' ' + is);
        //             const results = template.content.children;

        //             $('.variant-values label:contains("Size")').last().parent().after($(results));
        //             break;
        //         case 'material':
        //             im++;
        //             template.innerHTML = val3.replace('#value-here#', text + ' ' + im);
        //             const resultm = template.content.children;

        //             $('.variant-values label:contains("Material")').last().parent().after($(resultm));
        //             break;
        //     }
        // })



        //---------------------------------------------------


        document.getElementsByClassName('checkbox_animated').forEach((e) => {
            e.addEventListener('change', e => {
                if (e.target.checked) {
                    $(`<th class='${e.target.value}'>${e.target.value}</th>`).insertBefore('#1st');
                    document.getElementsByClassName('1st').forEach(function (fc, i) {
                        const th = document.createElement('th');
                        th.classList.add(`${e.target.value}`);
                        if (e.target.value == 'color') {
                            th.innerHTML = val1.replace('ProductItem', `createProductItemViewModel.ProductItems[${i}]`);
                        }
                        else if (e.target.value == 'size') {
                            th.innerHTML = val2.replace('ProductItem', `createProductItemViewModel.ProductItems[${i}]`);
                        }
                        else {
                            th.innerHTML = val3.replace('ProductItem', `createProductItemViewModel.ProductItems[${i}]`);
                        }
                        fc.parentElement.insertBefore(th, fc);
                    })
                }
                else
                    $(`.${e.target.value}`).each(function () { $(this).remove() });

            })
        });


    let index = 0;
                     
        $('.add-variant').on('click', (e) => {
        index += 1;
    let row = $('.t-body .body-row:last-child')
    let sku = row.find('input[type=text]')[0].value + 'N' + row.find('input[type=text]')[1].value;
    for (let i = 0; i < row.find("select").length; i++) {
        sku = row.find("select")[i].value.substr(0, 1) + sku;
            }
    row.find('p')[0].textContent = sku;
    row.find('.sku_input').val(sku);
    let replaceTRext = row[0].innerHTML.substring(row[0].innerHTML.indexOf('['), row[0].innerHTML.indexOf(']') + 1);
    let replaceSKU = row[0].innerHTML.substring(row[0].innerHTML.indexOf('<p>') + 3, row[0].innerHTML.indexOf('</p>'));
    $('.t-body').append('<tr class="body-row">' + row[0].innerHTML.replaceAll(replaceTRext, `[${index}]`).replace(replaceSKU, 'Auto generated SKU') + '</tr>')
            $('.t-body .body-row:last-child').find("td:nth-last-child(3)").on('click', (e) => {
        let row = $(e.currentTarget.parentElement);
    let sku = row.find('input[type=text]')[0].value + 'N' + row.find('input[type=text]')[1].value;
    for (let i = 0; i < row.find("select").length; i++) {
        sku = row.find("select")[i].value.substr(0, 1) + sku;
                }

    $(e.currentTarget).find('p')[0].textContent = sku;
            })

    //-------
    let lastInput = $('.t-body .body-row:last-child');
            lastInput.find('.upload__inputfile').on('click', (e) => {
        $('.upload__box1').css({
            'visibility': 'visible'
        })
    }) //show img-wrap

    var imgWrap = "";


    imgWrap = $('.upload__img-wrap');
    var maxLength = lastInput.find('.upload__inputfile').attr('data-max_length');
    var imgArray = [];



            lastInput.find('.upload__btn').on('click', '.upload__button', e => {
        $(e.currentTarget).closest('.t-body').find('input[type=file]').each((w, z) => { $(z).removeClass('current_input'); })
                $(e.currentTarget.parentElement).find('input[type=file]').addClass('current_input');

    let iterator = 0;
                if (imgArray.length > 0) {
        imgArray.forEach(function (f, index) {

            var reader = new FileReader();
            reader.onload = function (b) {
                var html = "<div class='upload__img-box'><div style='background-image: url(" + b.target.result + ")' data-number='" + $(".upload__img-close").length + "' data-file='" + f.name + "' class='img-bg'><div class='upload__img-close'></div></div></div>";
                let jqElement = $(html);
                imgWrap[0].insertBefore(jqElement[0], $('.upload__img-add')[0].parentElement);
                iterator++;

                jqElement.on('click', ".upload__img-close", function (e) {
                    var file = $(this).parent().data("file");
                    for (var i = 0; i < imgArray.length; i++) {
                        if (imgArray[i].name === file) {
                            imgArray.splice(i, 1);
                            break;
                        }
                    }
                    $(this).parent().parent().remove();
                });

            }
            reader.readAsDataURL(f);

        })
    }

            })

    lastInput.find('.upload__inputfile').on('change', function (e) {
        //let imgArray = [];

        let files = lastInput.find('.upload__inputfile')[0].files;
    let filesArr = Array.prototype.slice.call(files);
    let iterator = 0;
                if (files.length > 0) {
        filesArr.forEach(function (f, index) {

            if (!f.type.match('image.*')) {
                return;
            }

            if (imgArray.length > maxLength) {
                return false
            } else {
                var len = 0;
                for (var i = 0; i < imgArray.length; i++) {
                    if (imgArray[i] !== undefined) {
                        len++;
                    }
                }
                if (len > maxLength) {
                    return false;
                } else {
                    imgArray.push(f);

                    var reader = new FileReader();
                    reader.onload = function (b) {
                        var html = "<div class='upload__img-box'><div style='background-image: url(" + b.target.result + ")' data-number='" + $(".upload__img-close").length + "' data-file='" + f.name + "' class='img-bg'><div class='upload__img-close'></div></div></div>";
                        let jqElement = $(html);
                        imgWrap[0].insertBefore(jqElement[0], $('.upload__img-add')[0].parentElement);
                        iterator++;
                    }
                    reader.readAsDataURL(f);
                }
            }
        });
                }
            })

        })

        $('.t-body').on('click', "td:nth-last-child(3)", (e) => {
        let row = $(e.currentTarget.parentElement);
    let sku = row.find('input[type=text]')[0].value + 'N' + row.find('input[type=text]')[1].value;
    for (let i = 0; i < row.find("select").length; i++) {
        sku = row.find("select")[i].value.substr(0, 1) + sku;
            }

    $(e.currentTarget).find('p')[0].textContent = sku;

    row.find('.sku_input').val(sku);

        })

        $('#cancel').on('click', (e) => {
        e.preventDefault();
    $('.upload__box1').css({
        'visibility': 'hidden'
            })

            $('.upload__img-box > :not(.upload__img-add)').parent().each(function (e) {
        $(this).remove()
    });

        })

        $('#add').on('click', e => {
        let lastInput = $('.t-body .body-row:last-child').find('.upload__inputfile');
    var files = new FormData()
    files.append('source', lastInput[0].files)

    $.ajax({
        url: '/Admin/ProductItem/AddMedia',
    type: 'POST',
    data: files,
    processData: false,
    contentType: false,
    success: function (data) {
        console.log(data);
                }
            });

        })

        // ---------------------------------------

            // $('.upload__btn')[0].addEventListener('click', e => {
        //     console.log('here: ', $(e.currentTarget).find('input[type=file]'))
        //     $(e.currentTarget).closest('.t-body').find('input[type=file]').each(() => { $(this).removeClass('current_input'); })
        //     $(e.currentTarget).find('input[type=file]').addClass('current_input');
        //     // e.stopPropagation();
        //     // return false;
        // })

        // $('.upload__img-add')[0].parentElement.addEventListener('click', () => {
        //     $('.upload__inputfile .current_input').click();
        // })

        $(document).ready(function () {
            ImgUpload();
        });

    function ImgUpload() {
        let imgWrap = "";
    let imgArray = [];

    $('.upload__inputfile').each(function () {
        $(this).on('change', function (e) {
            imgWrap = $('.upload__img-wrap');
            let maxLength = $(this).attr('data-max_length');
            let files = e.target.files;
            let filesArr = Array.prototype.slice.call(files);
            let iterator = 0;
            filesArr.forEach(function (f, index) {

                if (!f.type.match('image.*')) {
                    return;
                }

                if (imgArray.length > maxLength) {
                    return false
                } else {
                    var len = 0;
                    for (var i = 0; i < imgArray.length; i++) {
                        if (imgArray[i] !== undefined) {
                            len++;
                        }
                    }
                    if (len > maxLength) {
                        return false;
                    } else {
                        imgArray.push(f);

                        var reader = new FileReader();
                        reader.onload = function (b) {
                            var html = "<div class='upload__img-box'><div style='background-image: url(" + b.target.result + ")' data-number='" + $(".upload__img-close").length + "' data-file='" + f.name + "' class='img-bg'><div class='upload__img-close'></div></div></div>";
                            let jqElement = $(html);
                            imgWrap[0].insertBefore(jqElement[0], $('.upload__img-add')[0].parentElement);
                            iterator++;
                        }
                        reader.readAsDataURL(f);
                    }
                }
            });
        });
                });
    $('.upload__inputfile').each(function () {
        $(this).on('click', function (e) {
            imgWrap = $('.upload__img-wrap');
            let maxLength = $(this).attr('data-max_length');
            let files = e.target.files;
            let filesArr = Array.prototype.slice.call(files);
            let iterator = 0;
            filesArr.forEach(function (f, index) {

                if (!f.type.match('image.*')) {
                    return;
                }

                if (imgArray.length > maxLength) {
                    return false
                } else {
                    var len = 0;
                    for (var i = 0; i < imgArray.length; i++) {
                        if (imgArray[i] !== undefined) {
                            len++;
                        }
                    }
                    if (len > maxLength) {
                        return false;
                    } else {
                        imgArray.push(f);

                        var reader = new FileReader();
                        reader.onload = function (b) {
                            var html = "<div class='upload__img-box'><div style='background-image: url(" + b.target.result + ")' data-number='" + $(".upload__img-close").length + "' data-file='" + f.name + "' class='img-bg'><div class='upload__img-close'></div></div></div>";
                            let jqElement = $(html);
                            imgWrap[0].insertBefore(jqElement[0], $('.upload__img-add')[0].parentElement);
                            iterator++;
                        }
                        reader.readAsDataURL(f);
                    }
                }
            });
        });
            });

    $('body').on('click', ".upload__img-close", function (e) {
                var file = $(this).parent().data("file");
    for (var i = 0; i < imgArray.length; i++) {
                    if (imgArray[i].name === file) {
        imgArray.splice(i, 1);
    break;
                    }
                }
    $(this).parent().parent().remove();
            });

            $('.upload__inputfile').on('click', (e) => {
        $('.upload__box1').css({
            'visibility': 'visible'
        })
    })

            $('#cancel').on('click', (e) => {
        $('.upload__box1').css({
            'visibility': 'hidden'
        })

                $('.upload__img-box > :not(.upload__img-add)').parent().each(function (e) {
        console.log($(this))
                    $(this).remove()
                });

            })
        }
