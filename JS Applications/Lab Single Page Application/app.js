function solve(){
    initialize();
    let yearsSection = document.getElementById('years');
    yearsSection.style.display = 'block';

    let monthToNumber = {
        Jan : 1,
        Feb : 2,
        Mar : 3,
        Apr : 4,
        May : 5,
        Jun : 6,
        Jul : 7,
        Aug : 8,
        Sept : 9,
        Oct : 10,
        Nov : 11,
        Dec : 12,
    }

    yearsSection.addEventListener('click', (y) =>{
        y.preventDefault();
        let targetYear = y.target;
        if(targetYear.tagName == 'TD'){
            let year = targetYear.children[0].textContent;
            let monthSection = document.getElementById("year-"+year);
            y.currentTarget.style.display = 'none';
            monthSection.style.display = 'block';

            monthSection.addEventListener('click', (m) =>{
                m.preventDefault();
                let targetMonth = m.target;
                if(targetMonth.tagName == 'CAPTION'){
                    yearsSection.style.display = 'block';
                    monthSection.style.display = 'none';      
                } else if(targetMonth.tagName == 'TD'){
                    let monthText = targetMonth.children[0].textContent; 
                    let text = "month-"+year+'-'+monthToNumber[monthText];
                    let daysSection = document.getElementById(text);
                    monthSection.style.display = 'none';
                    daysSection.style.display = 'block';

                    daysSection.addEventListener('click', (d) => {
                        let targetDay = d.target

                        if(targetDay.tagName == 'CAPTION'){
                            monthSection.style.display = 'block';
                            daysSection.style.display = 'none';    
                        }
                    });
                }

            });
        }

    });

    function initialize() {
        let allSectionElements = document.querySelectorAll('section');
        Array.from(allSectionElements)
        .forEach(e => e.style.display ='none');
    }
}

solve()