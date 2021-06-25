function solve(ticketsInfo, sortType) {
    class Ticket{
        constructor(destination, price, status){
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }
    let tickets = [];
    ticketsInfo.forEach(ticketInfo => {
        let [destination, price, status] = ticketInfo.split('|');
        let ticket = new Ticket(destination, Number(price), status);
        tickets.push(ticket);
    });
    if(sortType == 'destination'){
        tickets.sort((a,b)=>a.destination.localeCompare(b.destination));
    } else if (sortType == 'price'){
        tickets.sort((a,b)=> a.price - b.price);
    } else {
        tickets.sort((a,b)=>a.status.localeCompare(b.status));
    }
    return tickets;
}

console.log(solve(['Philadelphia|94.20|available'], 'status'));