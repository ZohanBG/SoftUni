function solve(input, fullCriteria) {
  let parsedInputs = JSON.parse(input);
  let counter = 0;
  if(fullCriteria == 'all'){
    for (const item of parsedInputs) {
      console.log(`${counter}. ${item["first_name"]} ${item["last_name"]} - ${item.email}`);
      counter++;
    }
  } else {
      let [data,criteria] = fullCriteria.split('-');
      for (const item of parsedInputs) {
          if(item[data] == criteria){
            console.log(`${counter}. ${item["first_name"]} ${item["last_name"]} - ${item.email}`);
            counter++;
          }
      }
  }
}


solve(`[{
    "id": "1",
    "first_name": "Kaylee",
    "last_name": "Johnson",
    "email": "k0@cnn.com",
    "gender": "Female"
  }, {
    "id": "2",
    "first_name": "Kizzee",
    "last_name": "Johnson",
    "email": "kjost1@forbes.com",
    "gender": "Female"
  }, {
    "id": "3",
    "first_name": "Evanne",
    "last_name": "Maldin",
    "email": "emaldin2@hostgator.com",
    "gender": "Male"
  }, {
    "id": "4",
    "first_name": "Evanne",
    "last_name": "Johnson",
    "email": "ev2@hostgator.com",
    "gender": "Male"
  }]`,
 'all'

);
