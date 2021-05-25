function solve(steps, stride, speedInKmPh) {

    let distance=steps*stride
    let speedInMPs=speedInKmPh/3.6;
    
    let time = distance/speedInMPs;
    let breaks=Math.trunc(distance/500);
    time += breaks*60;

    let hours = Math.trunc(time/3600);
    let minutes = Math.trunc((time % 3600) / 60);
    let seconds = Math.round(time % 60);
    console.log(`${hours.toString().padStart(2,"0")}:${minutes.toString().padStart(2,"0")}:${seconds.toString().padStart(2,"0")}`);
}

solve(4000, 0.60, 5)