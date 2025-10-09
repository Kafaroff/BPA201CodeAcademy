let soz = "codeacademy"; 
let arr = soz.split(""); 

let tersArr = []; 

for (let i = arr.length - 1; i >= 0; i--) {
  tersArr.push(arr[i]);
}

let tersSoz = tersArr.join("");

if (soz === tersSoz) {
  console.log("Bu söz palindromdur");
} else {
  console.log("Bu söz palindrom deyil");
}

