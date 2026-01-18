using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities (low, medium, high).
    // Expected Result: Dequeue should return the item with the highest numeric priority value first.
    // Defect(s) Found: 
    public void TestPriorityQueue_HighestPriorityReturnedFirst()
    {
        var priorityQueue = new PriorityQueue();
        
        // Enqueue items: (Value, Priority)
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 10);
        priorityQueue.Enqueue("Medium", 5);

        // Expected: "High" (10) comes out first
        string result1 = priorityQueue.Dequeue();
        Assert.AreEqual("High", result1, "The item with the highest priority (10) should be returned first.");

        // Expected: "Medium" (5) comes out second
        string result2 = priorityQueue.Dequeue();
        Assert.AreEqual("Medium", result2, "The item with the next highest priority (5) should be returned next.");

        // Expected: "Low" (1) comes out last
        string result3 = priorityQueue.Dequeue();
        Assert.AreEqual("Low", result3, "The item with the lowest priority (1) should be returned last.");
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the SAME highest priority.
    // Expected Result: Dequeue should follow FIFO (First-In, First-Out) for items with the same priority.
    // Defect(s) Found: 
    public void TestPriorityQueue_FIFO_Strategy_On_Ties()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First_High", 10);
        priorityQueue.Enqueue("Second_High", 10);
        priorityQueue.Enqueue("Low", 1);

        // Both have priority 10, but "First_High" was added first.
        string result1 = priorityQueue.Dequeue();
        Assert.AreEqual("First_High", result1, "On ties, the item added first should be removed first (FIFO).");

        string result2 = priorityQueue.Dequeue();
        Assert.AreEqual("Second_High", result2, "The next highest priority item should be returned.");
    }

    [TestMethod]
    // Scenario: Attempt to Dequeue from an empty queue.
    // Expected Result: Should throw an InvalidOperationException with the message "The queue is empty."
    // Defect(s) Found: 
    public void TestPriorityQueue_EmptyQueue_ThrowsException()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("An exception should have been thrown, but it was not.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message, "The exception message matches the requirement.");
        }
        catch (Exception e)
        {
            Assert.Fail($"Wrong exception type thrown. Expected: InvalidOperationException. Actual: {e.GetType()}");
        }
    }
}