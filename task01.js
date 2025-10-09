let array = [ 5,5423,4,2,523,5,235,235,23,523,5]
let h=0
silinecek=523
a=array.length

for(let i=0; i<a; i++){
    if(array[i]==silinecek){
        array.splice(i,1)
        h++
    }
}
if(h==0){
    console.log("Not Found")
}
while(h>0){
    array.push(0)
    h--
}

console.log(array)