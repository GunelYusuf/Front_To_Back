//let arrowLeft=document.getElementById('arrowLeft');
//let arrowRight=document.getElementById('arrowRight');
//let Anna=document.querySelector('.Anna');
//let Jasmine=document.querySelector('.Jasmine');
//let Count=0;
//setInterval(function(){
//    Count++;
//  if(Count<=1){
//     Jasmine.style.display='block';
//     Anna.style.display='none';
//  }else{
//    Count=0;
//    Anna.style.display='block';
//    Jasmine.style.display='none';
//  }
//}, 3000);
//arrowLeft.onclick=()=>{
//   Count++;
//  if(Count<=1){
//     Jasmine.style.display='block';
//     Anna.style.display='none';
//  }else{
//    Count=0;
//    Anna.style.display='block';
//    Jasmine.style.display='none';
//  }
//}
//arrowRight.onclick=()=>{
//   Count++;
//  if(Count<=1){
//     Jasmine.style.display='block';
//     Anna.style.display='none';
//  }else{
//    Count=0;
//    Anna.style.display='block';
//    Jasmine.style.display='none';
//  }
//}

$(document).ready(function () {
    //search

    $("#input-search").on("keyup", "#input-search", function ()
    {
        $("#search-list li").slice(1).remove();
        let search = $("#input-search").val().trim();
        if (search.length > 0) {
            $.ajax({

                url: "/product/search?search=" + search,
                type: "get",
                success: function (res) {
                    $("#search-list").append(res);
                }
            })
        }
      
    }
    )

    //load More
    let count = $("#count").val();
    let skip = 8;
    $(document).on("click", "#loadMore", function () {
        alert("ok");
        $.ajax({
            url: "/product/LoadMore?skip=" + skip,
            method:"get",
            success: function (resp) {
                
                for (var item of resp) {
                    //let diving = $("<div>").addClass("image");
                    //let img = $("<img>").attr("scr", "/Products-Images/" + item.ImageUrl)
                    //link.append(img);
                    //diving.append(link);

                    //let divtitle = $("<div>").addClass("title text-center");
                    //let p = $("<p>").text(item.Name);
                    //divtitle.append(p)
                    //let divprice = $("<div>").addClass("add-cart");
                    //let spanaddcart = $("<p>").addClass("addBasket").text("Add to cart")
                    //divprice.append(spanaddcart)

                    //let divpric = $("<div>").addClass("price");
                    //let span = $("<span>").text("$")
                    //let spanspice = $("<span>").addClass("totalPrice").text(item.Price)
                    //divpric.append(span, spanspice)

                    //let divproduct = $("<div>").addClass("product-list").attr('data-id', item.CATEGORY1.Name);
                    //divproduct.append(divimg, divtitle, divprice);
                    //let divcol = $("<div>").addClass("col-lg-3 col-md-6 col-xs-12")
                    //divcol.append(divproduct);
                    $("#productrow").append(res);
                   
               
                }
            }
        })
        skip += 8;
        if (skip >= count) {
            $("#loadMore").remove();
        }
    })

    $("#products-card .products-navbar h6").click(function () {
        $("products-card .products-navbar ul").slideToggle(500);
    });
})

let heading_li = document.querySelectorAll("#products-card .products-navbar ul li a");
let show_products = document.querySelectorAll("#allProducts .same_product");

for (let a of heading_li) {
    a.addEventListener("click", function (e) {
        e.preventDefault();
        document.querySelector("#products-card .products-navbar ul .selected").classList.remove("selected");
        this.classList.add("selected");
        let data_id = this.parentElement.getAttribute("data-id");
        for (let sp of show_products) {
            if (data_id == sp.getAttribute("data-id")) {
                sp.classList.remove("d-none");
            }
            else {
                sp.classList.add("d-none");
            }
        }
    })
}


