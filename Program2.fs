// For more information see https://aka.ms/fsharp-console-apps

type Coach = {
    Name: string
    FormerPlayer: bool
}

type Stats = {
    Wins: int
    Losses: int
}

type Team = {
    Name: string
    Coach: Coach
    Stats: Stats
}

let coach1 = { Name = "Joe Mazzulla"; FormerPlayer = true }
let coach2 = { Name = "Michael Malone"; FormerPlayer = false }
let coach3 = { Name = "Jason Kidd"; FormerPlayer = true }
let coach4 = { Name = "Erik Spoelstra"; FormerPlayer = false }
let coach5 = { Name = "Doc Rivers"; FormerPlayer = false }

let stats1 = { Wins = 64; Losses = 18 }  
let stats2 = { Wins = 57; Losses = 25 }  
let stats3 = { Wins = 50; Losses = 32 }  
let stats4 = { Wins = 46; Losses = 36 }  
let stats5 = { Wins = 17; Losses = 19 }  

let team1 = { Name = "Boston Celtics"; Coach = coach1; Stats = stats1 }
let team2 = { Name = "Denver Nuggets"; Coach = coach2; Stats = stats2 }
let team3 = { Name = "Dallas Mavericks"; Coach = coach3; Stats = stats3 }
let team4 = { Name = "Miami Heat"; Coach = coach4; Stats = stats4 }
let team5 = { Name = "Milwaukee Bucks"; Coach = coach5; Stats = stats5 }

let teams = [team1; team2; team3; team4; team5]

teams
|> List.iter (fun team -> 
    printfn "Team: %s, Coach: %s, Wins: %d, Losses: %d" 
        team.Name team.Coach.Name team.Stats.Wins team.Stats.Losses)

let successPercentages = 
    teams 
    |> List.choose (fun team -> 
        if team.Stats.Wins > team.Stats.Losses then 
            let successRate = (float team.Stats.Wins) / (float (team.Stats.Wins + team.Stats.Losses)) * 100.0
            Some (team.Name, successRate)
        else None)


printfn "\nTeams with winning records and their success percentages:"
successPercentages 
|> List.iter (fun (teamName, percentage) -> 
    printfn "Team: %s, Success Percentage: %.2f%%" 
        teamName percentage)





