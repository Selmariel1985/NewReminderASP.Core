function openNav() {
    document.getElementById("mySidebar").style.width = "250px";
    document.getElementById("main").style.marginLeft = "250px";
}

function closeNav() {
    document.getElementById("mySidebar").style.width = "0";
    document.getElementById("main").style.marginLeft = "0";
}



// Click outside to close dropdown
window.onclick = function (event) {
    if (!event.target.matches('.dropdown-toggle')) {
        var dropdowns = document.getElementsByClassName("dropdown-menu");
        for (var i = 0; i < dropdowns.length; i++) {
            var openDropdown = dropdowns[i];
            if (openDropdown.style.display === 'block') {
                openDropdown.style.display = 'none';
            }
        }
    }
}

var inactivityTime = 0;
var checkInterval = 1000;
var timeoutSeconds = 60;
var countdownInterval;

function resetTimer() {
    inactivityTime = 0;
    clearInterval(countdownInterval); // Сбросить интервал обратного отсчета при сбросе таймера
    startCountdown(); // Перезапустить обратный отсчет после сброса таймера
}

function checkInactivity() {
    inactivityTime += checkInterval;
    if (inactivityTime >= timeoutSeconds * 1000) {
        clearInterval(countdownInterval);
        signOutAndRedirectToLogin('AccountsArea');
    }
}

setInterval(checkInactivity, checkInterval);

document.addEventListener('click', resetTimer);
document.addEventListener('mousemove', resetTimer);
document.addEventListener('keypress', resetTimer);

function startCountdown() {
    var seconds = timeoutSeconds;
    var countdownElement = document.getElementById('countdown');

    countdownElement.innerText = 'Time left: ' + seconds + ' seconds'; // Обновить отображение обратного отсчета в начале

    countdownInterval = setInterval(function () {
        seconds--;
        countdownElement.innerText = 'Time left: ' + seconds + ' seconds'; // Обновить отображение обратного отсчета

        if (seconds <= 0) {
            clearInterval(countdownInterval);
            countdownElement.innerText = 'Time is up!';
        } else if (seconds <= 15) {
            countdownElement.style.color = 'red'; // Изменить цвет текста в красный при 15 секундах
        }
    }, 1000);
}

startCountdown();



function signOutAndRedirectToLogin(area) {
    $.ajax({
        url: '/AccountsArea/User/SignOut',
        type: 'POST',
        data: { area: area },
        success: function (response) {
            // Обработка успешного выхода
            window.location.href = '/LoginArea/Login/Login?ReturnUrl=%2f';
        },
        error: function (xhr, status, error) {
            console.error(error);
        }
    });
}