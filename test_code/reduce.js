const numbers = [15.5, 2.3, 1.1, 4.7];

console.log(numbers.reduce(getSum, []));

function getSum(total, num) {
  total.push(num);
  //   console.log(total);
  return total;
  //   return total + Math.round(num);
}
