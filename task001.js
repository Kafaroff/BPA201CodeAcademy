<<<<<<< HEAD
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
=======
let yas=36;
let pensiyaYasi=65;
if(yas>0 && yas<125){
    if(yas>=pensiyaYasi){
        console.log("Artiq pensiya yasinizdir tebrikler!")
    }
    else{
        console.log("Hele var pensiyaya cixmagina")
    }
}
else{
    console.log("Yasiniz 0-125 araliginda olmalidir")
}
>>>>>>> d5100eb (Tasks)
