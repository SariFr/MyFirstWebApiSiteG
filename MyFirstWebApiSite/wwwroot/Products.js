﻿async function getAllProduct(url) {
    try {
        const prod = JSON.parse(sessionStorage.getItem('products'))
        if (!prod)
            document.querySelector('.ItemCount').innerText =0
        else
            document.querySelector('.ItemCount').innerText = prod.length
        const res = await fetch(url)
        if (!res.ok)
            throw new Error("failed")
        const products = await res.json()

        if (products) {
            document.getElementById('counter').innerText = products.length
            document.getElementById('PoductList').replaceChildren([]);

            products.map(p =>
                drawProduct(p)
            );
        }
            
        else
            alert("not found product");

        //sessionStorage.setItem("currentUser", JSON.stringify(data))
    }
    catch (ex) {
        alert(ex.message)
    }
}

async function getAllCategory() {
    try {
        const res = await fetch('api/category')
        if (!res.ok)
            throw new Error("failed")
        const categories = await res.json()

        if (categories)
            categories.map(c =>
                showCategory(c)
            );

        else
            alert("not found product");

        //sessionStorage.setItem("currentUser", JSON.stringify(data))
    }
    catch (ex) {
        alert(ex.message)
    }
}
async function drawProduct(p) {
    const temp = document.getElementById('temp-card')
    const clone = temp.content.cloneNode(true)
    clone.querySelector("img").src = "./pictures/" + p.image.trim()
    clone.querySelector("h1").innerText = p.name
    clone.querySelector(".price").innerText = p.price
    clone.querySelector(".description").innerText = p.des
    clone.querySelector("button").addEventListener('click', () => addToCart(p))


    document.getElementById('PoductList').appendChild(clone);
} 
let listToSession = []
count=0
async function addToCart(p) {
    const products = JSON.parse(sessionStorage.getItem('products'))
    if (products) {
        const prod = products.filter(pr => p.productId == pr.productId)
        if (prod.length == 0) {
            listToSession = products
            count = products.length
            count++
            document.querySelector('.ItemCount').innerText = count
            listToSession.push(p)
            sessionStorage.setItem('products', JSON.stringify(listToSession))
        }

    }
    else {
        count++
        document.querySelector('.ItemCount').innerText = count
        listToSession.push(p)
        sessionStorage.setItem('products', JSON.stringify(listToSession))
    }
    }



async function showCategory(c) {
    const temp = document.getElementById('temp-category')
    const clone = temp.content.cloneNode(true)
    clone.querySelector("label").for = c.name
    clone.querySelector("input").innerText = c.name
    clone.querySelector("input").id = c.categoryId;
    clone.querySelector(".OptionName").innerText = c.name

    const list = document.getElementById('categoryList');
    list.appendChild(clone);
}

async function filterProducts() {
    let url = 'https://localhost:44383/api/product'
    let categories = []
    let allCategoryOption = document.querySelectorAll(".opt");
    for (let i = 0; i < allCategoryOption.length; i++) {
        if (allCategoryOption[i].checked)
            categories.push(allCategoryOption[i].id)
    }
    let name = document.getElementById("nameSearch").value
    let minPrice = document.getElementById("minPrice").value
    let maxPrice = document.getElementById("maxPrice").value

    if (name || categories || minPrice || maxPrice)
        url += '?'
    if (name)
        url += 'name=' + name
    if (minPrice)
        url += '&minPrice=' + minPrice
    if (maxPrice)
        url += '&maxPrice=' + maxPrice
    if (categories)
    { 
        for (let i = 0; i < categories.length; i++)
        {
            url += '&categoryIds=' + categories[i]
        }
    }


    getAllProduct(url);

}