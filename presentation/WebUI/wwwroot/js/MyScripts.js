
$('#addItem').on('click', (e) => {
    e.preventDefault();
$.get("/Admin/ProductItem/AddProductItem?ui-culture=az-AZ", {productid: 'fdfdfdf' }, (data) => showModal(data))
})

const showModal = (card) => {
    $('#popup-overlay').css({
        'visibility': 'visible'
    })

    $('#popup-overlay').append(card);
    const modal = document.getElementById('productItemModal');
    modal.style.position = 'relative';
    modal.style.top = '50%';
    modal.style.left = '50%';
    modal.style.width = '1100px';
    modal.style.minHeight = '600px';
    modal.style.maxHeight = '500px';
    modal.style.overflow = 'auto';
    modal.style.transform = 'translate(-50%, -50%)';
    $('#productItemModal').css({'border': '1px solid black', 'z-index': '9999' });
    $('#popup-overlay').css({'opacity': '100%' });
}





const val = `<div class="row mt-1 align-items-center variant-values">
    <label class="col-sm-3 col-form-label form-label-title">#value-here#</label>
    <div class="col-sm-9">
        <div class="bs-example">
            <select class="js-example-basic-single w-100" name="state">
                <option>In Stock</option>
                <option>Out Of Stock</option>
                <option>On Backorder</option>
            </select>
        </div>
    </div>
</div>`;
let ic = 0;
let is = 0;
let im = 0;

$('.add-option').on('click', (e) => {
    e.preventDefault();
    var text = $('.variant-selector')[0].options[$('.variant-selector')[0].selectedIndex].text;
    const template = document.createElement('template');
    switch (text.toLowerCase()) {
        case 'color':
            ic++;
            template.innerHTML = val.replace('#value-here#', text + ' ' + ic);
            const resultc = template.content.children
            $('.variant-values label:contains("Color"):last').parent().after($(resultc));
            break;
        case 'size':
            is++;
            template.innerHTML = val.replace('#value-here#', text + ' ' + is);
            const results = template.content.children
            $('.variant-values label:contains("Size")').last().parent().after($(results));
            break;
        case 'material':
            im++;
            template.innerHTML = val.replace('#value-here#', text + ' ' + im);
            const resultm = template.content.children
            $('.variant-values label:contains("Material")').last().parent().after($(resultm));
            break;
    }
})
