var readline = require("readline");
let rl = readline.createInterface({
  input: process.stdin,
});

let lines = [];

rl.on("line", function (line) {
  lines.push(line);
});

rl.on("close", function (line) {
  console.log("close");
  solve(lines);
});

function solve(lines) {}
