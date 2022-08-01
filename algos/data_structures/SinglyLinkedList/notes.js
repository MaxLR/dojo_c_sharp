const node1 = { data: 1, next: null };
const node2 = { data: 2, next: null };
const node3 = { data: 3, next: null };

node1.next = node2;
node2.next = node3;

let currentNode = node1;

while(currentNode != null) {
    console.log(currentNode.data)
    currentNode = currentNode.next
}