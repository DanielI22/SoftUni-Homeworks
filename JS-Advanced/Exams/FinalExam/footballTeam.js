class footballTeam {
    constructor(clubName, country) {
        this.clubName = clubName;
        this.country = country;
        this.invitedPlayers = [];
    }

    newAdditions(footballPlayers) {
        let addedPlayers = new Set();
        for(let player of footballPlayers) {
            let [name,age,playerValue] = player.split('/');
            let currentPlayer = this.invitedPlayers.find(pl => pl.name == name);
            if(currentPlayer != undefined) {
                if(playerValue > currentPlayer.playerValue) {
                    currentPlayer.playerValue == playerValue;
                }
            }
            else {
                let newPlayer = {
                    name,
                    age,
                    playerValue
                }
                this.invitedPlayers.push(newPlayer);
                addedPlayers.add(newPlayer.name);
            }
        }
        return `You successfully invite ${new Array(...addedPlayers).join(', ')}.`;
    }

    signContract(selectedPlayer) {
        let [name,playerOffer] = selectedPlayer.split('/');
        let currentPlayer = this.invitedPlayers.find(pl => pl.name == name);
        if(currentPlayer == undefined) {
            throw new Error(`${name} is not invited to the selection list!`);
        }
        if(playerOffer < currentPlayer.playerValue) {
            let priceDifference = currentPlayer.playerValue - playerOffer;
            throw new Error(`The manager's offer is not enough to sign a contract with ${name}, ${priceDifference} million more are needed to sign the contract!`);
        }
        currentPlayer.playerValue = "Bought";
        return `Congratulations! You sign a contract with ${name} for ${playerOffer} million dollars.`
    }

    ageLimit(name, age) {
        let currentPlayer = this.invitedPlayers.find(pl => pl.name == name);
        if(currentPlayer == undefined) {
            throw new Error(`${name} is not invited to the selection list!`);
        }
        if(currentPlayer.age < age) {
            let ageDiff = age - currentPlayer.age;
            if(ageDiff < 5) {
                return `${name} will sign a contract for ${ageDiff} years with ${this.clubName} in ${this.country}!`
            }
            else {
                return `${name} will sign a full 5 years contract for ${this.clubName} in ${this.country}!`;
            }
        }
        else {
            return `${name} is above age limit!`;
        }
    }

    transferWindowResult() {
        let result = "Players list:";
        this.invitedPlayers.sort((a,b) => a.name.localeCompare(b.name));
        this.invitedPlayers.forEach(pl => {
            result += `\nPlayer ${pl.name}-${pl.playerValue}`;
        })

        return result;
    }
}

let fTeam = new footballTeam("Barcelona", "Spain");
 console.log(fTeam.newAdditions(["Kylian Mbappé/23/160", "Lionel Messi/35/50", "Pau Torres/25/52"]));
