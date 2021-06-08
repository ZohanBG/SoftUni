function hydrateWorker(worker) {
    if(worker.dizziness == true){

        worker.dizziness = false;
        worker.levelOfHydrated = (0.1 * worker.weight) *  worker.experience;
    }
    return worker;
}

let obj = hydrateWorker({ weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true }
  );

  console.log(obj);