//import axios from '../js/axios/axios.js';
//const axios = require('../js/axios/axios.js');
//import axios from "../../node_modules/axios/index.js";
//import '../../node_modules/dotenv/config.js';
//import axios from "/node_modules/axios/index.js";
//import axios from "axios";

//import MailtrapClient from "/lib/mailtrap/dist/index.js";
console.log(testData);

let sendMailBtn = document.querySelector(".sendMailBtn");
console.log(sendMailBtn);

(async () => {
    email_access_data = await axios.get("http://localhost:5189/Home/GetMailAccess");
    console.log(email_access_data);
})();

sendMailBtn.addEventListener("click", async function (e) {

    console.log(1);
    let SendToWhere = document.querySelector(".emailToWhere");
    if (SendToWhere.value.length > 0) {
        let sendEmailRes =  await axios.post("https://send.api.mailtrap.io/api/send", {
            "to": [
                {
                    "email":"dbdf0147@gmail.com",
                    "name": "TestUser"
                }
            ],
            "from": {
                "email": "sales@example.com",
                "name": "Reset Password"
            },
            "subject": "Reset Password",
            "text": "Please reset your email"
        })
        console.log(sendEmailRes);
        console.log("send");
        //if (sendEmailRes)
    }
});
