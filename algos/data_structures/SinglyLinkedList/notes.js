//manually creating ListNode "objects"
const node1 = { data: 1, next: null };
const node2 = { data: 2, next: null };
const node3 = { data: 3, next: null };

//assigning the next nodes in our list
node1.next = node2;
node2.next = node3;

let currentNode = node1;

//"looping" through our singly linked list based on current node existing
while(currentNode != null) {
    console.log(currentNode.data)
    currentNode = currentNode.next
}