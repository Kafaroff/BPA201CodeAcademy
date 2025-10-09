let arr=[345,52345,345,34,53,3,53]
c=arr.length;
a = arr[0];

for (let i = 0; i < c; i++) {
  if(arr[i]>a){
    a=arr[i]
}
  
}

console.log("Ededlerin en boyuku:"+a)