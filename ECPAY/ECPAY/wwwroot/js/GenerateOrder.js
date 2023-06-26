﻿let createOrderBtn = document.querySelector(".createOrderBtn");

console.log(createOrderBtn);

function padTo2DigitsWithZero(num, digit) {
    return num.toString().padStart(digit, '0');
}


// create Date format: yyyy/MM/dd HH:mm:ss
function formatDate(date) {
    return (
        [
            date.getFullYear(),
            padTo2DigitsWithZero(date.getMonth()),
            padTo2DigitsWithZero(date.getDate())
        ].join('/') +
        ' ' +
        [
            padTo2DigitsWithZero(date.getHours()),
            padTo2DigitsWithZero(date.getMinutes()),
            padTo2DigitsWithZero(date.getSeconds())
        ]
    )
}

createOrderBtn.addEventListener("click", async function (e) {
    const data = {
        "MerchantID": "3002599",
        "MerchantTradeNo": "123455",
        "MerchantTradeDate": formatDate(new Date()),
        "PaymentType": "aio",
        "TotalAmount": 1000,
        "TradeDesc": "test data",
        "ItemName": "棒棒冰",
        "ReturnURL": "http://localhost:5177/Home/OrderReturn",
        "ChoosePayment":"ALL",
        "EncryptType":1
    };
    console.log(data);

    let unEncodeText = `ChoosePayment=${data.ChoosePayment}&EncryptType=${data.EncryptType}&ItemName=${data.ItemName}&MerchantID=${data.MerchantID}&
    MerchantTradeDate=${data.MerchantTradeDate}&MerchantTradeNo=${data.MerchantTradeNo}&PaymentType=${data.PaymentType}&ReturnURL=${data.ReturnURL}&TradeDesc=${data.TradeDesc}`;

    data["CheckMacValue"] = unEncodeText;

    try {

        let res = await axios.post("http://localhost:5177/Home/CreateOrder", {
            headers: {
                "content-type": "application/json;charset=utf-8"
            },
            data: JSON.stringify(data)
        })
        console.log(res);
        console.log(res.data);
    } catch (e) {
        console.log(e);
    }
});