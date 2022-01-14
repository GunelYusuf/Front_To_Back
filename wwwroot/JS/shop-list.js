$('.shoplicards').owlCarousel({
    autoplay: true,
    items: 4,
    loop:true,
    margin:20,
    nav:true,
    dots:false,
    navText: ["<i class='fas fa-caret-left'></i>","<i class='fas fa-caret-right'></i>" ],
    navText:top,
    responsive:{
        0:{
            items:1
        },
        600:{
            items:2
        },
        1000:{
            items:4
        }
    }
})