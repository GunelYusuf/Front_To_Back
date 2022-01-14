let openSidebar = document.querySelector('.navbar-icon .icon .openSidebar');
            let close = document.querySelector('header .navbar .close')

            openSidebar.addEventListener('click', function () {
                document.body.classList.add('active');
            })

            close.addEventListener('click', function () {
                document.body.classList.remove('active');
            })

            $(document).ready(function () {
                $('header .navbar .navbar-list ul li a').click(function () {
                    if ($(this).next().attr('class') == 'fas fa-caret-right') {
                        $(this).next().removeClass('fa-caret-right');
                        $(this).next().addClass('fa-caret-down');
                    }
                    else {
                        $(this).next().removeClass('fa-caret-down');
                        $(this).next().addClass('fa-caret-right');
                    }
                    $(this).next().next().slideToggle(500);
                });
            })