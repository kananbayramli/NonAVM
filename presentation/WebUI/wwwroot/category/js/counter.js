// const counts = document.querySelectorAll('.count')
// const speed = 97

// counts.forEach((counter) => {
//     function upDate() {
//         const target = Number(counter.getAttribute('data-target'))
//         const count = Number(counter.innerText)
//         const inc = target / speed
//         if (count < target) {
//             counter.innerText = Math.floor(inc + count)
//             setTimeout(upDate, 15)
//         } else {
//             counter.innerText = target
//         }
//     }
//     upDate()
// })








// const counters = document.querySelectorAll('.count')
// const speed = 97
// let animationStarted = false

// function isInViewport(element) {
//     const rect = element.getBoundingClientRect()
//     return (
//         rect.top >= 0 &&
//         rect.left >= 0 &&
//         rect.bottom <= (window.innerHeight || document.documentElement.clientHeight) &&
//         rect.right <= (window.innerWidth || document.documentElement.clientWidth)
//     )
// }

// function startCounterAnimation() {
//     counters.forEach((counter) => {
//         function upDate() {
//             const target = Number(counter.getAttribute('data-target'))
//             const count = Number(counter.innerText)
//             const inc = target / speed
//             if (count < target) {
//                 counter.innerText = Math.floor(inc + count)
//                 setTimeout(upDate, 15)
//             } else {
//                 counter.innerText = target
//             }
//         }

//         // Reset the starting value to 0 before starting the animation
//         counter.innerText = '0'
//         upDate()
//     })
//     animationStarted = true
// }

// function handleScroll() {
//     const counterSection = document.getElementById('counter-section')
//     if (!animationStarted && isInViewport(counterSection)) {
//         startCounterAnimation()
//     }
// }

// window.addEventListener('scroll', handleScroll)



// const counters = document.querySelectorAll('.count')
// const speed = 97
// let animationStarted = false

// function isAnyPartInViewport(element) {
//     const rect = element.getBoundingClientRect()
//     const windowHeight = window.innerHeight || document.documentElement.clientHeight
//     return (
//         rect.top <= windowHeight &&
//         rect.bottom >= 0
//     )
// }

// function startCounterAnimation() {
//     counters.forEach((counter) => {
//         function upDate() {
//             const target = Number(counter.getAttribute('data-target'))
//             const count = Number(counter.innerText)
//             const inc = target / speed
//             if (count < target) {
//                 counter.innerText = Math.floor(inc + count)
//                 setTimeout(upDate, 30)
//             } else {
//                 counter.innerText = target
//             }
//         }

//         // Reset the starting value to 0 before starting the animation
//         counter.innerText = '0'
//         upDate()
//     })
//     animationStarted = true
// }

// function handleScroll() {
//     const counterSection = document.getElementById('counter-section')
//     if (!animationStarted && isAnyPartInViewport(counterSection)) {
//         startCounterAnimation()
//     }
// }

// window.addEventListener('scroll', handleScroll)


//new
const counters = document.querySelectorAll('.count');
const speed = 97;

function isPartiallyInViewport(element) {
    const rect = element.getBoundingClientRect();
    const windowHeight = window.innerHeight || document.documentElement.clientHeight;
    const elementHeight = rect.height || element.offsetHeight;
    const visibleHeight = Math.min(elementHeight, Math.max(0, windowHeight - rect.top, rect.bottom - windowHeight));
    return (visibleHeight / elementHeight) * 100 >= 50; // At least 50% of the element is visible
}

function parseIntegerFromString(str) {
    return parseInt(str.replace(/[^0-9]/g, ''), 10);
}

function startCounterAnimation() {
    counters.forEach((counter) => {
        const target = parseIntegerFromString(counter.getAttribute('data-target'));
        const inc = target / speed;
        let count = 0;

        function update() {
            if (count < target) {
                count += inc;
                counter.innerText = Math.floor(count);
                requestAnimationFrame(update);
            } else {
                counter.innerText = target;
            }
        }

        update();
    });
}

function handleScroll() {
    const counterSection = document.getElementById('counter-section');
    if (isPartiallyInViewport(counterSection)) {
        startCounterAnimation();
        window.removeEventListener('scroll', handleScroll);
    }
}

window.addEventListener('scroll', handleScroll);