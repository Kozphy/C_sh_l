let n = 153;
let n_s = n.toString();
let n_l = n_s.length;
let res = 0;

for (let i = 0; i < n_l; i++) {
  let num = 0;
  num = Number(n_s[i]) ** Number(n_l);
  res += num;
}

console.log(res);
