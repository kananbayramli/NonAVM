function startCountdown() {
    const saleEndDate = new Date("2023-09-25T23:59:59").getTime();

    const countdownInterval = setInterval(function() {
        const now = new Date().getTime();
        const timeRemaining = saleEndDate - now;

        if (timeRemaining <= 0) {
            clearInterval(countdownInterval);
            document.getElementById("countdown_2").innerHTML = "Sale has ended!";
        } else {
            const days = Math.floor(timeRemaining / (1000 * 60 * 60 * 24));
            const hours = Math.floor((timeRemaining % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
            const minutes = Math.floor((timeRemaining % (1000 * 60 * 60)) / (1000 * 60));
            const seconds = Math.floor((timeRemaining % (1000 * 60)) / 1000);

            document.getElementById("countdown_2").innerHTML = `${days}d : ${hours}h : ${minutes}m : ${seconds}s`;
        }
    }, 1000);
}

function closeSale() {
    document.getElementById("sale-container").style.display = "none";
}

startCountdown();