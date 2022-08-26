/**
 * Class to represent a queue using an array to store the queued items.
 * Follows a FIFO (First In First Out) order where new items are added to the
 * back and items are removed from the front.
 */
class Queue {
    constructor() {
      this.items = [];
    }

    /**
     * Determines whether the sum of the left half of the queue items is equal to
     * the sum of the right half. Avoid indexing the queue items directly via
     * bracket notation, use the queue methods instead for practice.
     * Use no extra array or objects.
     * The queue should be returned to it's original order when done.
     * - Time: O(n).
     * - Space: O(1).
     * @returns {boolean} Whether the sum of the left and right halves is equal.
    */
    isSumOfHalvesEqual() {
      if (this.isEmpty() || this.items.length == 1) return true
      let leftSum = 0
      let rightSum = 0
      const queueLength = this.size()

      for(let i = 0; i < queueLength; i++) {
        let tempVal = this.dequeue()

        if (i < Math.floor(queueLength / 2)) {
          leftSum += tempVal
        } else if (i >= Math.ceil(queueLength / 2)) {
          rightSum += tempVal
        }

        this.enqueue(tempVal)
      }

      return leftSum == rightSum
    }

    /**
     * Compares this queue to another given queue to see if they are equal.
     * Avoid indexing the queue items directly via bracket notation, use the
     * queue methods instead for practice.
     * Use no extra array or objects.
     * The queues should be returned to their original order when done.
     * - Time: O(n^2) quadratic, n = queue length. Quadratic due to dequeue on an
     *     array queue being O(n).
     * - Space: O(1) constant.
     * @param {Queue} q2 The queue to be compared against this queue.
     * @returns {boolean} Whether all the items of the two queues are equal and
     *    in the same order.
     */
    compareQueues(q2) {
      if (this.size() !== q2.size()) {
        return false;
      }
      let count = 0;
      let isEqual = true;
      const len = this.size();

      while (count < len) {
        const dequeued1 = this.dequeue();
        const dequeued2 = q2.dequeue();

        if (dequeued1 !== dequeued2) {
          isEqual = false;
        }

        this.enqueue(dequeued1);
        q2.enqueue(dequeued2);
        count++;
      }
      return isEqual;
    }

    /**
     * Determines if the queue is a palindrome (same items forward and backwards).
     * Avoid indexing queue items directly via bracket notation, instead use the
     * queue methods for practice.
     * Use only 1 stack as additional storage, no other arrays or objects.
     * The queue should be returned to its original order when done.
     * - Time: O(n^2) quadratic, n = queue length. Quadratic due to dequeue on an
     *     array queue being O(n).
     * - Space: O(n) from the stack being used to store the items again.
     * @returns {boolean}
     */
    isPalindrome() {
      let isPalin = true;
      const stack = new Stack(),
        len = this.size();

      for (let i = 0; i < len; i++) {
        let dequeued = this.dequeue();
        stack.push(dequeued);
        // add it back so the queue items and order is restored at the end
        this.enqueue(dequeued);
      }

      for (let i = 0; i < len; i++) {
        let dequeued = this.dequeue();
        let popped = stack.pop();

        if (popped !== dequeued) {
          isPalin = false;
        }

        // add it back so the queue items and order is restored at the end
        this.enqueue(dequeued);
      }
      return isPalin;
    }
  
    /**
     * Adds a new given item to the back of this queue.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @param {any} item The new item to add to the back.
     * @returns {number} The new size of this queue.
     */
    enqueue(item) {
      this.items.push(item);
      return this.size();
    }

    /**
     * Removes and returns the first item of this queue.
     * - Time: O(n) linear, due to having to shift all the remaining items to
     *    the left after removing first elem.
     * - Space: O(1) constant.
     * @returns {any} The first item or undefined if empty.
     */
    dequeue() {
      return this.items.shift();
    }

    /**
     * Retrieves the first item without removing it.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {any} The first item or undefined if empty.
     */
    front() {
      return this.items[0];
    }

    /**
     * Returns whether or not this queue is empty.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {boolean}
     */
    isEmpty() {
      return this.items.length === 0;
    }

    /**
     * Retrieves the size of this queue.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {number} The length.
     */
    size() {
      return this.items.length;
    }
}


let qa = new Queue()
let qb = new Queue()

qa.enqueue(1)
qa.enqueue(3)
qa.enqueue(5)

qa.enqueue(5)

qa.enqueue(1)
qa.enqueue(1)
qa.enqueue(3)

console.log(qa.isSumOfHalvesEqual(qb))

console.log(qa.items)
