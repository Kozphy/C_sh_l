const sentence = "ES5到ESNext 精準進擊 JS 語法與核心";

const hasWords = sentence.includes("進擊"); // true
const hasWordsFrom = sentence.includes("進擊", 16); // false

console.log(hasWords);
console.log(hasWordsFrom);
