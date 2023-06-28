let lastPageBtn = document.querySelector(".lastPageBtn");
let totalPage = await GetTotalPage();

async function GetTotalPage() {
    try {
        let res = await axios.get("http://localhost:5011/Home/GetDbTableTotalPage")
        if (res.status == 200) {
            return res.data
        }
    } catch (ex) {
        console.log(ex);
    }
}

function RenderPagination() {
    let start = 1;
    let end = 10;
    let pagination = document.querySelector(".pagination");
    let arr = ['<li class="page-item"><a class="page-link" href="#">Previous</a></li>',
        '<li class="page-item"><a class="page-link" href="#">Next</a></li>'
    ];
    for (let i = start; i < end; i++) {
        arr.splice(arr.length-1, 0, `<li class="page-item"><a class="page-link" href="#">${i}</a></li>`
        );
    }
    arr = arr.join("");

    pagination.insertAdjacentHTML('beforeend', arr);
}

RenderPagination();

lastPageBtn.addEventListener("click",  async function (e) {
    
});



