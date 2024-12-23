using System;
using System.Collections.Generic;
using System.Linq;

namespace WindowsFormsApp9
{
    public class MemoryManager
    {
        private Queue<double> _memoryValues = new Queue<double>(); 
        private const int MaxMemorySize = 4; 

       
        public void ClearMemory()
        {
            _memoryValues.Clear();
        }

        
        public double RecallMemory()
        {
            if (_memoryValues.Count > 0)
                return _memoryValues.Last(); // 마지막 값 반환
            throw new InvalidOperationException("Memory is empty.");
        }

        
        public void AddToMemory(double value)
        {
            if (_memoryValues.Count > 0)
            {
                double lastValue = _memoryValues.Last();
                _memoryValues = new Queue<double>(_memoryValues.Take(_memoryValues.Count - 1));
                _memoryValues.Enqueue(lastValue + value);
            }
            else
            {
                StoreToMemory(value);
            }
        }

        
        public void SubtractFromMemory(double value)
        {
            if (_memoryValues.Count > 0)
            {
                double lastValue = _memoryValues.Last();
                _memoryValues = new Queue<double>(_memoryValues.Take(_memoryValues.Count - 1));
                _memoryValues.Enqueue(lastValue - value);
            }
            else
            {
                StoreToMemory(-value);
            }
        }

        
        public void StoreToMemory(double value)
        {
           
            if (_memoryValues.Count >= MaxMemorySize)
            {
                _memoryValues.Dequeue(); 
            }

            _memoryValues.Enqueue(value); 
        }

        
        public List<double> GetMemoryValues()
        {
            return _memoryValues.ToList(); // Queue를 List로 변환
        }
    }
}
