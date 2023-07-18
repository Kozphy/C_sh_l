let x = Date.parse("1997-07-14").valueOf();
let StartDate = new Date(1997, 6, 4);
StartDate = Date.parse(StartDate).valueOf();
let EndDate = new Date();
EndDate = Date.parse(EndDate).valueOf();
// console.log(x)
// console.log(StartDate)
// console.log(EndDate)
// console.log(StartDate<x && EndDate>x)

var data = [
  {
    orderDate: "1997-07-10",
    name: "Sirop d\u0027erable",
    categories: "Condiments",
    id: 10595,
    quentity: 120,
    price: 28.5,
    total: 3420.0,
  },
  {
    orderDate: "1997-10-22",
    name: "Rogede sild",
    categories: "Seafood",
    id: 10713,
    quentity: 110,
    price: 9.5,
    total: 1045.0,
  },
  {
    orderDate: "1998-02-18",
    name: "Rhonbrau Klosterbier",
    categories: "Beverages",
    id: 10894,
    quentity: 120,
    price: 7.75,
    total: 930.0,
  },
  {
    orderDate: "1998-02-18",
    name: "Guarana Fantastica",
    categories: "Beverages",
    id: 10895,
    quentity: 110,
    price: 4.5,
    total: 495.0,
  },
  {
    orderDate: "1998-04-13",
    name: "Raclette Courdavault",
    categories: "Dairy Products",
    id: 11017,
    quentity: 110,
    price: 55.0,
    total: 6050.0,
  },
  {
    orderDate: "1998-05-05",
    name: "Wimmers gute Semmelknodel",
    categories: "Grains/Cereals",
    id: 11072,
    quentity: 130,
    price: 33.25,
    total: 4322.5,
  },
  {
    orderDate: "1997-10-21",
    name: "Perth Pasties",
    categories: "Meat/Poultry",
    id: 10711,
    quentity: 120,
    price: 32.8,
    total: 3936.0,
  },
  {
    orderDate: "1997-12-03",
    name: "Chartreuse verte",
    categories: "Beverages",
    id: 10764,
    quentity: 130,
    price: 18.0,
    total: 2340.0,
  },
  {
    orderDate: "1997-12-15",
    name: "Manjimup Dried Apples",
    categories: "Produce",
    id: 10776,
    quentity: 120,
    price: 53.0,
    total: 6360.0,
  },
  {
    orderDate: "1997-09-23",
    name: "Jack\u0027s New England Clam Chowder",
    categories: "Seafood",
    id: 10678,
    quentity: 120,
    price: 9.65,
    total: 1158.0,
  },
];

// function compare(a, b) {
//   let a_Date = new Date(a.orderDate);
//   let b_Date = new Date(b.orderDate);
//   if (a_Date > b_Date) {
//     return -1;
//   } else {
//     return 1;
//   }
// }
// data.sort(compare);
// console.log(data);

var group = data.reduce(function (result, current) {
  result[current["orderDate"]] = result[current["orderDate"]] || [];
  result[current["orderDate"]].push(current);
  return result;
}, {});

function groupbysomething(Json, Target) {
  var something = Json.reduce(function (result, current) {
    result[current[Target]] = result[current[Target]] || [];
    result[current[Target]].push(current);
    return result;
  }, {});
  //   console.log(something);
  return something;
}

var Test = groupbysomething(data, "orderDate");
// // console.log(Test);
// const dataArray = Object.entries(Test);
// dataArray.sort((a, b) => {
//   new Date(a[0]) - new Date(a[0]);
// });

// console.log(dataArray);

// const dataObject = dataArray.reduce((obj, [date, value]) => {
//   obj[date] = value;
//   return obj;
// }, {});
// console.log(dataObject);
// console.log(Test.sort(compare));
// for (i = 0; i < data.length; i++) {
//   var uu = Object.values(Test)[i][0];
//   console.log(uu);
// }
