function animateAbout() {
    let element = document.getElementById("about-skills")

    if (element != undefined) {
        let position = element.getBoundingClientRect();
        if (window.pageYOffset > position.top || document.body.scrollTop > position.top) {
            let elements = document.getElementsByClassName("skill-bar");

            for (let i = 0; i < elements.length; i++) {
                elements[i].className = 'skill-bar skill-bar-animation';
            }
        }
    }
}

function seeMoreTimeline(id) {
    let internalDiv = document.getElementById('timeline-exp-internal-' + id)
    let timelineBar = document.getElementById('timeline-bar-' + id)
    timelineBar.style.height = `${internalDiv.offsetHeight + 40}px`

    let timelineTechs = document.getElementById('timeline-techs-' + id)
    let timelineAttri = document.getElementById('timeline-attri-' + id)
    let timelineSeeMore = document.getElementById('timeline-seemore-' + id)
    let timelineSeeLess = document.getElementById('timeline-seeless-' + id)

    timelineSeeMore.style.opacity = '0';
    timelineSeeMore.style.display = 'none';

    timelineTechs.style.opacity = '1';
    timelineAttri.style.opacity = '1';
    timelineSeeLess.style.opacity = '1';

    if (id != 'exp1')
        seeLessTimeline('exp1');
    if (id != 'exp2')
        seeLessTimeline('exp2');
    if (id != 'exp3')
        seeLessTimeline('exp3');
}

function seeLessTimeline(id) {
    let timelineBar = document.getElementById('timeline-bar-' + id)
    timelineBar.style.height = '255px'

    let timelineTechs = document.getElementById('timeline-techs-' + id)
    let timelineAttri = document.getElementById('timeline-attri-' + id)
    let timelineSeeMore = document.getElementById('timeline-seemore-' + id)
    let timelineSeeLess = document.getElementById('timeline-seeless-' + id)

    timelineSeeMore.style.opacity = '1';
    timelineSeeMore.style.display = 'flex';

    timelineTechs.style.opacity = '0';
    timelineAttri.style.opacity = '0';
    timelineSeeLess.style.opacity = '0';
}