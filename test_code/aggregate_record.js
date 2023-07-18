const transactions = [
  {
    name: "Rakesh",
    amount: 1500,
  },
  {
    name: "Rajesh",
    amount: 1200,
  },
  {
    name: "Ramesh",
    amount: 1750,
  },
  {
    name: "Rakesh",
    amount: 2100,
  },
  {
    name: "Mukesh",
    amount: 1100,
  },
  {
    name: "Rajesh",
    amount: 1950,
  },
  {
    name: "Mukesh",
    amount: 1235,
  },
  {
    name: "Ramesh",
    amount: 2000,
  },
];

const aggregateArray = (arr) => {
  //   console.log(arr);
  return arr.reduce((acc, val) => {
    const index = acc.findIndex((obj) => {
      console.log(`obj.name: ${obj.name} === val.name: ${val.name}`);
      return obj.name === val.name;
    });
    if (index !== -1) {
      acc[index].amount += val.amount;
    } else {
      acc.push({
        name: val.name,
        amount: val.amount,
      });
    }
    return acc;
  }, []);
};

console.log(aggregateArray(transactions));
