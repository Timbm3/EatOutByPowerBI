//<button class="showDessert">Dessert visa</button>

        //<div hidden class="col-sm-6 rightMenu hideOnClick showDessert">
        //    <h2>Dessert</h2>
        //    <ul>
        //        <li>Vegetarisk gul curry med tofu, potatis, morot och kokosmjölk</li>
        //    </ul>
        //</div>


//Show Dessert
$(document).ready(function () {
    $('.showDessert').click('click', function (event) {
        $('.hideOnClick').hide('hide'),
            $('.showDessert').show('show');
    });
});

//Show Dryck
$(document).ready(function () {
    $('.showAlaCarte').click('click', function (event) {
        $('.showAlaCarte').show('show'),
        $('.hideOnClick').hide('hide');
    });
});