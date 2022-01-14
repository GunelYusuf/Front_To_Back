    let menu = document.querySelectorAll('.menu');
    let allcontents = document.getElementById('1a');
    let change;
    menu.forEach(g => {
    g.onclick = () => {
    let dataId = g.getAttribute('data-id');
    let content = document.getElementById(dataId);
    if (dataId != '1a') {
    allcontents.style.display = 'none';
    }
    if (change) {
     change.style.display = 'none';
    }
    content.style.display = 'block';
    change = content;
            }
        });

          let check1 = document.querySelectorAll('.check1');
            let allcontexts = document.getElementById('4a');
            let wrap;
            check1.forEach(g => {
                g.onclick = () => {
                    let dataId = g.getAttribute('data-id');
                    let context = document.getElementById(dataId);
                    if (dataId != '1a') {
                        allcontexts.style.display = 'none';
                    }
                    if (wrap) {
                        wrap.style.display = 'none';
                    }
                    context.style.display = 'block';
                    wrap = context;
                }
            });
         
            let check2 = document.querySelectorAll('.check2');
            let alltexts = document.getElementById('7a');
            let tabtext;
            check2.forEach(g => {
                g.onclick = () => {
                    let dataId = g.getAttribute('data-id');
                    let zara = document.getElementById(dataId);
                    if (dataId != '1a') {
                        alltexts.style.display = 'none';
                    }
                    if (tabtext) {
                        tabtext.style.display = 'none';
                    }
                    zara.style.display = 'block';
                    tabtext = zara;
                }
            });

                let check3 = document.querySelectorAll('.check3');
                let  allLongtext= document.getElementById('10a');
                let changed;
                check3.forEach(g => {
                    g.onclick = () => {
                        let dataId = g.getAttribute('data-id');
                        let longTab = document.getElementById(dataId);
                        if (dataId != '1a') {
                            allLongtext.style.display = 'none';
                        }
                        if (changed) {
                            changed.style.display = 'none';
                        }
                        longTab.style.display = 'block';
                        changed=longTab;
                    }
                });