using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISDHomeWork.lesson4.BinaryT
{
    public class BinaryTree
    {
        private Node _headNode = null;

        private int _count = 0;
        public int Count { get => _count; }

        public Node Root { get => _headNode; }

        /// <summary>
        /// Добавления новой записи в дерево
        /// </summary>
        /// <param name="node">Новая запсиь</param>
        /// <returns>true - если новая запись добавелась в дерево; false - если запись с таким значением уже содержится в дереве</returns>
        public bool AddNode(Node node)
        {
            if (_headNode == null)
            {
                _headNode = node;
                _count++;

                return true;
            }

            //Проверка на дубликат значения
            if (FindeNode(node.Value) != null)
                return false;

            Node temporaryNode = _headNode;

            while (true)
            {
                if (node.Value > temporaryNode.Value)
                {
                    if (temporaryNode._rightNode == null)
                    {
                        node._parentNode = temporaryNode;
                        temporaryNode._rightNode = node;
                        _count++;
                        break;
                    }
                    else
                        temporaryNode = temporaryNode._rightNode;
                }

                if (node.Value < temporaryNode.Value)
                {
                    if (temporaryNode._leftNode == null)
                    {
                        node._parentNode = temporaryNode;
                        temporaryNode._leftNode = node;
                        _count++;
                        break;
                    }
                    else
                        temporaryNode = temporaryNode._leftNode;
                }
            }

            return true;
        }

        /// <summary>
        /// Поиск узла в дереве
        /// </summary>
        /// <param name="value">Значение для поиска в дереве</param>
        /// <returns>Node - если запись содержиться в дереве; null - если записи нет в дереве</returns>
        public Node FindeNode(int value)
        {
            Node temporaryNode = _headNode;

            while (temporaryNode != null)
            {
                if (value == temporaryNode.Value)
                    return temporaryNode;

                if (value > temporaryNode.Value)
                {
                    temporaryNode = temporaryNode._rightNode;
                    continue;
                }

                if (value < temporaryNode.Value)
                {
                    temporaryNode = temporaryNode._leftNode;
                }
            }

            return null;
        }

        /// <summary>
        /// Удвление узла из дерева
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool DeleteNode(int value)
        {
            Node temporaryNode = FindeNode(value);

            if (temporaryNode == null)
                return false;

            #region Случай - когда удаляемый узел не имеет дочерних узлов

            if (temporaryNode._leftNode == null && temporaryNode._rightNode == null)
            {
                //Проверка на удаление листа
                if (_count != 1)
                {
                    if (temporaryNode._parentNode._leftNode == temporaryNode)
                        temporaryNode._parentNode._leftNode = null;
                    else
                        temporaryNode._parentNode._rightNode = null;
                }
                if (_headNode == temporaryNode)
                    _headNode = null;
                temporaryNode = null;
                _count--;

                return true;
            }

            #endregion

            #region Случай, когда удаляемый узел имеет только один из дочерних узлов

            if (temporaryNode._leftNode == null)
            {
                if (temporaryNode == _headNode)
                {
                    _headNode = temporaryNode._rightNode;
                    temporaryNode._rightNode = null;
                    _headNode._parentNode = null;

                    temporaryNode = null;
                    _count--;

                    return true;
                }

                
                if (temporaryNode._parentNode._leftNode == temporaryNode)
                    temporaryNode._parentNode._leftNode = temporaryNode._rightNode;
                else
                    temporaryNode._parentNode._rightNode = temporaryNode._rightNode;

                temporaryNode._rightNode._parentNode = temporaryNode._parentNode;

                temporaryNode = null;
                _count--;

                return true;
            }

            if (temporaryNode._rightNode == null)
            {
                if (temporaryNode == _headNode)
                {
                    _headNode = temporaryNode._leftNode;
                    temporaryNode._leftNode = null;
                    _headNode._parentNode = null;

                    temporaryNode = null;
                    _count--;

                    return true;
                }

                if (temporaryNode._parentNode._leftNode == temporaryNode)
                    temporaryNode._parentNode._leftNode = temporaryNode._leftNode;
                else
                    temporaryNode._parentNode._rightNode = temporaryNode._leftNode;

                temporaryNode._leftNode._parentNode = temporaryNode._parentNode;

                temporaryNode = null;
                _count--;

                return true;
            }

            #endregion

            #region Случай, когда узел имеет два дочерхних узла

            //Минимальный узел в правом поддереве удаляемого узла и родитель мин. узла
            Node rightMinNode = temporaryNode._rightNode;
            Node parentRightMinNode;

            //Поиск минимальной вершины и ее родителя
            while (rightMinNode._leftNode != null)
            {
                rightMinNode = rightMinNode._leftNode;
            }
            parentRightMinNode = rightMinNode._parentNode;

            //Если минимальный узел имеет правую вершину
            if (rightMinNode._rightNode != null)
            {
                rightMinNode._leftNode = temporaryNode._leftNode;
                if (temporaryNode == _headNode && temporaryNode == parentRightMinNode)
                {
                    _headNode = rightMinNode;
                    rightMinNode._leftNode = temporaryNode._leftNode;
                    temporaryNode._leftNode._parentNode = rightMinNode;

                    temporaryNode = null;
                    _count--;

                    return true;
                }
                else if (temporaryNode == _headNode)
                {
                    rightMinNode._rightNode._parentNode = parentRightMinNode;
                    parentRightMinNode._leftNode = rightMinNode._rightNode;

                    rightMinNode._rightNode = temporaryNode._rightNode;

                    temporaryNode._leftNode._parentNode = rightMinNode;
                    temporaryNode._rightNode._parentNode = rightMinNode;

                    rightMinNode._parentNode = null;
                    _headNode = rightMinNode;

                    temporaryNode = null;
                    _count--;

                    return true;
                }
                else
                {
                    rightMinNode._rightNode._parentNode = parentRightMinNode;
                    parentRightMinNode._leftNode = rightMinNode._rightNode;

                    rightMinNode._rightNode = temporaryNode._rightNode;

                    temporaryNode._leftNode._parentNode = rightMinNode;
                    temporaryNode._rightNode._parentNode = rightMinNode;


                    Node parentTemporaryNode = temporaryNode._parentNode;
                    rightMinNode._parentNode = parentTemporaryNode;

                    if (parentTemporaryNode._leftNode == temporaryNode)
                        parentTemporaryNode._leftNode = rightMinNode;
                    else
                        parentTemporaryNode._rightNode = rightMinNode;

                    _count--;
                    temporaryNode = null;

                    return true;
                }
            }

            //Если минимальный узел не имеет ни одну из дочерних вершин
            if (rightMinNode._leftNode == null && rightMinNode._rightNode == null)
            {

                if (parentRightMinNode == _headNode)
                {
                    rightMinNode._parentNode = null;
                    rightMinNode._leftNode = parentRightMinNode._leftNode;
                    rightMinNode._leftNode._parentNode = rightMinNode;
                    _headNode = rightMinNode;

                    parentRightMinNode = null;
                    _count--;

                    return true;
                }

                if (temporaryNode == _headNode)
                {
                    parentRightMinNode._leftNode = null;
                    rightMinNode._parentNode = null;

                    rightMinNode._leftNode = _headNode._leftNode;
                    _headNode._leftNode._parentNode = rightMinNode;

                    rightMinNode._rightNode = _headNode._rightNode;
                    _headNode._rightNode._parentNode = rightMinNode;

                    _headNode = rightMinNode;

                    temporaryNode = null;
                    _count--;

                    return true;
                }

                //Если удаляемый узел является родителем минимального узла в правом поддереве
                if (parentRightMinNode == temporaryNode)
                {
                    rightMinNode._parentNode = parentRightMinNode._parentNode;
                    parentRightMinNode._rightNode = null;

                    if (parentRightMinNode._parentNode._leftNode == parentRightMinNode)
                        parentRightMinNode._parentNode._leftNode = rightMinNode;
                    else
                        parentRightMinNode._parentNode._rightNode = rightMinNode;

                    temporaryNode = null;
                    _count--;

                    return true;
                }

                rightMinNode._parentNode = temporaryNode._parentNode;
                parentRightMinNode._leftNode = null;

                temporaryNode._parentNode = null;

                rightMinNode._leftNode = temporaryNode._leftNode;
                rightMinNode._rightNode = temporaryNode._rightNode;

                //TODO: не работает при удаление головы с 2 узлами
                if (rightMinNode._parentNode._leftNode == temporaryNode)
                    rightMinNode._parentNode._leftNode = rightMinNode;
                else
                    rightMinNode._parentNode._rightNode = rightMinNode;

                temporaryNode = null;
                _count--;

                return true;
            }
            #endregion

            return false;
        }
    }
}
