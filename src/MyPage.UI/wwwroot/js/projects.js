let tagFilterElement = document.getElementById("tagFilter");
let tagFilter = tagFilterElement ? tagFilterElement.value : "";

function setTagFilter() {
    document.getElementById("tagFilter").value = tagFilter
    console.log(tagFilter)
}

function addOrRemoveSelectedTag(tagName) {
    if (tagFilter.includes(tagName)) {
        removeSelectedTag(tagName)
    }
    else {
        addSelectedTag(tagName)
    }
}

function addSelectedTag(tagName) {
    tagFilter = tagFilter + tagName + ';'
    setTagFilter()
    document.getElementById(tagName).className = "project-tag-search tag-selected";
}

function removeSelectedTag(tagName) {
    tagFilter = tagFilter.replace(tagName + ';', '');
    setTagFilter()
    document.getElementById(tagName).className = "project-tag-search";
}

function openVideoModal(videoUrl) {
    let video = document.getElementById("video");
    let modal = document.getElementById("modal");

    video.src = videoUrl;
    modal.style.display = "flex";

    setTimeout(() => {
        modal.style.opacity = "1";
    }, 200)
}

function closeVideoModal() {
    let video = document.getElementById("video");
    let modal = document.getElementById("modal");

    video.src = "";
    modal.style.opacity = "0";

    setTimeout(() => {
        modal.style.display = "none";
    }, 200)
}