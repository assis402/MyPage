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
    document.getElementById("video").src = videoUrl;
    document.getElementById("modal").style.display = "flex";

    setTimeout(() => {
        document.getElementById("modal").style.opacity = "1";
    }, 200)
}

function closeVideoModal() {
    document.getElementById("video").src = "";
    document.getElementById("modal").style.opacity = "0";

    setTimeout(() => {
        document.getElementById("modal").style.display = "none";
    }, 200)
}