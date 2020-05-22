const detail = document.querySelector('.detail');
const detailTitle = document.querySelector('.detail-title');
const masterItems = document.querySelectorAll('.master-item');

function select(selected) {
    for (var item of masterItems) {
        item.classList.remove('active-item');
    }

    selected.classList.add('active-item');
    if (selected == masterItems[0]) {
        document.getElementsByClassName('detail')[0].style.display = "block";
        document.getElementsByClassName('detail2')[0].style.display = "none";
    }
    else {
        document.getElementsByClassName('detail')[0].style.display = "none";
        document.getElementsByClassName('detail2')[0].style.display = "block";
    }
}

function back() {
    //Remove active class from all master-items
    for (var item of masterItems) {
        item.classList.remove('active-item');
    }
    detail.classList.add('hidden-md-down');
}

function showDetails() {
    if (document.getElementsByClassName('detailPatient')[0].style.display == "block") {
        document.getElementsByClassName('detailPatient')[0].style.display = "none";
    } else {
        document.getElementsByClassName('detailPatient')[0].style.display = "block";
    }
}