let arr=[1,2,3,4,5,6,7]
let arr2=[]
c=arr.length;

for(let i =0;i<c;i++){
    a=arr[i]
    b=0
    while(a>0){
        if(arr[i]%a==0){
            b++
        }
        a--
    }
    if(b<3){
        arr2.push(arr[i])
    }
}


console.log(arr2)