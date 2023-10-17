// Получаем данные от пользователя 
let P = prompt('Введите сообщение:'); 
 
// Вводим необходимые переменные 
let K = 0, 
 kSumm = 0, 
 t = 121; 
 
const a = 31, 
 b = 5, 
 c = 256, 
 MaxVal = 255; 
 
// Считаем контрольную сумму с помощью метода контрольных сумм 
function KSumm(d) { 
 d = +d; 
 while (d > 0) { 
 K += d % 10; 
 d = Math.floor(d / 10); 
 } 
 
 kSumm = K % (MaxVal + 1) 
 
 // Выводим получившееся значение 
 alert(`Контрольная сумма, полученная методом контрольных сумм: ${kSumm}`); 
} 
 
// Считаем контрольную сумму с помощью хэширования с применением гаммирования 
function SummKodBukvOtkr(d) { 
 let X = ''; 
 let A = d; 
 // Каждый символ переводим в восьмибитные двоичные 
 while (A.length > 0) { 
 let x = +A.slice(-1).toString(2); 
 while (x.length < 8) { 
 x = '0' + x; 
 } 
 X = x + X; 
 A = A.slice(0, -1); 
 } 
 
 // Вырабатываем последовательность псевдослучайных чисел и представляем в виде восьмибитных двоичных слов 
 A = d; 
 let m = t.toString(2); 
 while (m.length < 8) { 
 m = '0' + m; 
 } 
 let T = m; 
 for (let i = 1; i < A.length - 1; i++) { 
 t = (a * t + b) / c; 
 s = t.toString(2); 
 while (s.length < 8) { 
 s = '0' + s; 
 } 
 T = T + s; 
 } 
 
 // Складываем значения поразрядно по модулю 2 и переводим в десятичные 
 let Y = ''; 
 while (X.length > 0) { 
 let e = +X.slice(-1); 
 let f = +T.slice(-1); 
 let y; 
 if (e + f > 1) { 
 y = 0; 
 } else { 
 y = e + f; 
 } 
 y = y.toString(); 
 Y = y + Y; 
 X = X.slice(0, -1); 
 T = T.slice(0, -1); 
 } 
 let W = ''; 
 while (Y.length > 0) { 
 let w = +Y.slice(-8); 
 w = parseInt(w, 2); 
 w = w.toString(); 
 W = w + W; 
 Y = Y.slice(0, -8); 
 } 
 
 // Выводим получившееся значение 
 alert(`Контрольная сумма, полученная методом хэширования с применением гаммирования: ${W}`); 
} 
 
// Вызываем функции подсчета контрольных сумм 
KSumm(P); 
SummKodBukvOtkr(P);