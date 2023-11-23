let allprice = 0

async function getProductCart() {
    try {
        const products = JSON.parse(sessionStorage.getItem('products'))
        if (products) {
            document.getElementById('itemCount').innerText = products.length
            document.querySelector('tbody').replaceChildren([]);

            products.map(p =>
                drawProduct(p)
            );
            document.getElementById('totalAmount').innerText = allprice

        }

        else
            alert("not found product");

    }
    catch (ex) {
        alert(ex.message)
    }
}

async function drawProduct(p) {
    allprice += p.price
    const temp = document.getElementById('temp-row')
    const clone = temp.content.cloneNode(true)
    clone.querySelector(".image").src = "./pictures/" + p.image.trim()
    clone.querySelector(".itemName").innerText = p.name
    clone.querySelector(".price").innerText = p.price
    clone.querySelector("button").addEventListener('click', () => deleteProduct(p))


    const tbody = document.querySelector('tbody');
    tbody.appendChild(clone)
} 

async function deleteProduct(p)
{
    allprice -= p.price
    const products = JSON.parse(sessionStorage.getItem('products'))
    const prodCart = products.filter(prod => prod.productId != p.productId)
    sessionStorage.setItem('products', [])
    sessionStorage.setItem('products', JSON.stringify(prodCart))

    getProductCart()
}

async function placeOrder() {
    const user = sessionStorage.getItem('currentUser')
    if (!user)
        window.location.href = './home.html';
    else {
        try {
            const products = JSON.parse(sessionStorage.getItem('products'))
            const userId = JSON.parse(user).userId

            const orderSum = allprice
            const orderDate = new Date()
            const orderItem = []
            products.map(p => orderItem.push({ "ProductId": p.productId, "Quantity": 1 }));
            const order = { "userId": userId, "orderDate": orderDate, "orderSum": orderSum, "orderItem": orderItem }
            console.log(order)

            const res = await fetch("api/order", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(order)
            })
            if (!res.ok)
                throw new Error("Error add order to server")
            const data = await res.json()
            alert(`בוצעה בהצלחה ${data} הזמנתך מספר`)
            sessionStorage.setItem('products', [])
            window.location.href = './Products.html';

        }
        catch (ex) {
            alert("error")
        }
    }
}

