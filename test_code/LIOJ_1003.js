var readline = require("readline");
let rl = readline.createInterface({
  input: process.stdin,
});

let lines = [2, "yo", "man", 3, 4, 2, 1];

rl.on("line", function (line) {
  lines.push(line);
});

rl.on("close", function (line) {
  console.log("close");
  solve(lines);
});

function solve(lines) {
  let str = "";
  let res = "";
  for (let i = 1; i <= lines[0]; i++) {
    str += lines[i];
  }
  for (let i = lines[0] + 2; i < lines.length; i++) {
    res += str[lines[i]];
  }

  console.log(res);
}

solve(lines);
