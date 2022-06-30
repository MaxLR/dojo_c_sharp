/**
 * Class to represent a MinHeap which is a Priority Queue optimized for fast
 * retrieval of the minimum value. It is implemented using an array but it is
 * best visualized as a tree structure where each 'node' has left and right
 * children except the 'node' may only have a left child.
 * - parent is located at: Math.floor(i / 2);
 * - left child is located at: i * 2
 * - right child is located at: i * 2 + 1
 */
 class MinHeap {
    constructor() {
      /**
       * 0th index not used, so null is a placeholder. Not using 0th index makes
       * calculating the left and right children's index cleaner.
       * This also effectively makes our array start at index 1.
       */
      this.heap = [null];
    }

      /**
     * Extracts the min num from the heap and then re-orders the heap to
     * maintain order so the next min is ready to be extracted.
     * 1. Save the first node to a temp var.
     * 2. Pop last node off and set idx1 equal to the popped value.
     * 3. Iteratively swap the old last node that is now at idx1 with it's
     *    smallest child IF the smallest child is smaller than it.
     * - Time: O(log n) logarithmic due to shiftDown.
     * - Space: O(1) constant.
     * @returns {?number} The min number or null if empty.
     */
    extract() {}
  
  /**
   * Retrieves the top (minimum number) in the heap without removing it.
   * - Time: O(1) constant.
   * - Space: O(1) constant.
   * @returns {?number} Null if empty.
   */
   top() {
    return this.heap.length > 1 ? this.heap[1] : null;
  }

  /**
   * Inserts a new number into the heap and reorders heap to maintain order.
   * 1. Push new num to back.
   * 2. Iteratively swap the new num with it's parent while it is smaller than
   *    it's parent.
   * - Time: O(log n) logarithmic due to shiftUp.
   * - Space: O(1) constant.
   * @param {number} num The num to add.
   */
  insert(num) {
    this.heap.push(num);
    this.shiftUp();
    // .push on array returns the new length
    return this.size();
  }

  // AKA: siftUp, heapifyUp, bubbleUp to restore order after insert
  shiftUp() {
    // just to avoid repeatedly typing this.heap
    const heap = this.heap;
    let idxOfNodeToShiftUp = heap.length - 1;

    while (idxOfNodeToShiftUp > 1) {
      const idxOfParent = Math.floor(idxOfNodeToShiftUp / 2);

      // parent already smaller, no more swapping needed
      if (heap[idxOfParent] <= heap[idxOfNodeToShiftUp]) {
        break;
      }

      // while the parent is not smaller, swap it with it's child (array destructure syntax)
      // when the while loop is done, the new node is in it's correct place so all parents are smaller than children
      // prettier-ignore
      [heap[idxOfNodeToShiftUp], heap[idxOfParent]] = 
      [heap[idxOfParent], heap[idxOfNodeToShiftUp]];
      // since it was swapped with parent, it is now located at the idxOfParent
      idxOfNodeToShiftUp = idxOfParent;
    }
  }  
    /**
     * Logs the tree horizontally with the root on the left and the index in
     * parenthesis using reverse inorder traversal.
     */
    printHorizontalTree(parentIdx = 1, spaceCnt = 0, spaceIncr = 10) {
      if (parentIdx > this.heap.length - 1) {
        return;
      }
  
      spaceCnt += spaceIncr;
      this.printHorizontalTree(parentIdx * 2 + 1, spaceCnt);
  
      console.log(
        " ".repeat(spaceCnt < spaceIncr ? 0 : spaceCnt - spaceIncr) +
          `${this.heap[parentIdx]} (${parentIdx})`
      );
  
      this.printHorizontalTree(parentIdx * 2, spaceCnt);
    }
  }