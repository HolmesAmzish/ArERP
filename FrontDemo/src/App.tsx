// App.tsx (React + TypeScript)
import { useEffect, useState, useRef, useCallback } from "react";
import {
  DragDropContext,
  Droppable,
  Draggable,
  type DropResult,
} from "@hello-pangea/dnd";
import axios from "axios";

type Product = {
  id: number;
  code: string;
  name: string;
  type: number;
  unit: string;
  createDate: string;
};

type WorkOrder = {
  id: number;
  orderNumber: string;
  productItemId: number;
  product: Product;
  quantity: number;
  productionProcess: number;
  scheduledDate: string;
  status: number;
};

type Task = {
  id: number;
  content: string;
};

type TasksMap = Record<string, Task>;
type ScheduleMap = Record<string, string[]>;

const days = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday"];

const initialSchedule: ScheduleMap = {
  taskPool: [],
  Monday: [],
  Tuesday: [],
  Wednesday: [],
  Thursday: [],
  Friday: [],
};

const AnimatedCounter = ({ value }: { value: number }) => {
  const [displayValue, setDisplayValue] = useState(value);
  const requestRef = useRef<number | null>(null);
  const previousTimeRef = useRef<number | undefined>(undefined);

  const animate = useCallback(
    (time: number) => {
      if (previousTimeRef.current === undefined) {
        previousTimeRef.current = time;
      }

      const deltaTime = time - previousTimeRef.current;
      if (deltaTime > 16) {
        // ~60fps
        setDisplayValue((prev) => {
          const diff = value - prev;
          if (Math.abs(diff) < 0.5) return value;
          return prev + diff * 0.2;
        });
        previousTimeRef.current = time;
      }

      requestRef.current = requestAnimationFrame(animate);
    },
    [value]
  );

  useEffect(() => {
    requestRef.current = requestAnimationFrame(animate);
    return () => {
      if (requestRef.current) {
        cancelAnimationFrame(requestRef.current);
      }
    };
  }, [animate]);

  return <>{Math.round(displayValue)}%</>;
};

const App = () => {
  const [tasks, setTasks] = useState<TasksMap>({});
  const [schedule, setSchedule] = useState<ScheduleMap>(initialSchedule);
  const [overloads, setOverloads] = useState<Record<string, number>>({
    Monday: 0,
    Tuesday: 0,
    Wednesday: 0,
    Thursday: 0,
    Friday: 0,
  });
  useEffect(() => {
        axios.get("/api/production/workorders")
        .then((response) => {
            const workorders = response.data;

            const newTasks: TasksMap = {};
            const taskPoolIds: string[] = [];

            workorders.forEach((item: WorkOrder) => {
              const taskId = `${item.id}`;
              newTasks[taskId] = {
                id: item.id,
                content: `${item.orderNumber} - ${
                  item.product?.name || "Unknown Product"
                }`,
              };
              taskPoolIds.push(taskId);
            });

            setTasks(newTasks);
            setSchedule((prev) => ({ ...prev, taskPool: taskPoolIds }));
        });
  }, []);

  const onDragEnd = (result: DropResult): void => {
    const { source, destination } = result;

    if (!destination) return;

    const sourceList = Array.from(schedule[source.droppableId] || []);
    const destList = Array.from(schedule[destination.droppableId] || []);

    if (source.droppableId === destination.droppableId) {
      const [moved] = sourceList.splice(source.index, 1);
      sourceList.splice(destination.index, 0, moved);

      setSchedule((prev) => ({
        ...prev,
        [source.droppableId]: sourceList,
      }));
    } else {
      const [moved] = sourceList.splice(source.index, 1);
      const insertIndex = Math.min(destination.index, destList.length);
      destList.splice(insertIndex, 0, moved);

      setSchedule((prev) => ({
        ...prev,
        [source.droppableId]: sourceList,
        [destination.droppableId]: destList,
      }));

      if (days.includes(source.droppableId)) {
        setOverloads((prev) => ({
          ...prev,
          [source.droppableId]: Math.max(prev[source.droppableId] - 20, 0),
        }));
      }
      if (days.includes(destination.droppableId)) {
        setOverloads((prev) => ({
          ...prev,
          [destination.droppableId]: prev[destination.droppableId] + 20,
        }));
      }
    }
  };

  return (
    <div className="p-6 font-sans">
      <div className="flex justify-between items-center mb-6">
        <h1 className="text-2xl font-bold">任务时间安排</h1>
      </div>
      <DragDropContext onDragEnd={onDragEnd}>
        <div className="grid grid-cols-6 gap-4">
          {/* 工单容器整体 */}
          <div className="bg-gray-200 p-4 rounded shadow-lg min-h-[150px]">
            <h2 className="font-semibold text-lg mb-2">工单列表</h2>

            {/* Droppable 区域只包裹任务列表 */}
            <Droppable droppableId="taskPool">
              {(provided) => (
                <div
                  ref={provided.innerRef}
                  {...provided.droppableProps}
                  style={{ minHeight: 100 }}
                >
                  {schedule.taskPool.map((taskId, index) => (
                    <Draggable key={taskId} draggableId={taskId} index={index}>
                      {(provided) => (
                        <div
                          className="bg-gray-50 p-2 mb-2 rounded border hover:shadow-md transition duration-200"
                          ref={provided.innerRef}
                          {...provided.draggableProps}
                          {...provided.dragHandleProps}
                        >
                          {tasks[taskId]?.content}
                        </div>
                      )}
                    </Draggable>
                  ))}
                  {provided.placeholder}
                </div>
              )}
            </Droppable>
          </div>

          {days.map((day) => (
            <div
              key={day}
              className="bg-gray-200 p-4 rounded shadow-lg min-h-[150px]"
            >
              {/* title 和进度条 - 不属于Droppable */}
              <div className="flex justify-between items-center mb-2">
                <h2 className="font-semibold">{day}</h2>
                <div className="text-gray-700">
                  <AnimatedCounter value={overloads[day]} /> 负载
                </div>
              </div>
              <div className="w-full bg-gray-300 rounded-full h-2 mb-2">
                <div
                  className="bg-blue-500 h-2 rounded-full transition-all duration-300 ease-out"
                  style={{ width: `${Math.min(100, overloads[day])}%` }}
                ></div>
              </div>

              <Droppable droppableId={day}>
                {(provided) => (
                  <div
                    ref={provided.innerRef}
                    {...provided.droppableProps}
                    className="drop-area min-h-[450px]"
                  >
                    {schedule[day].map((taskId, index) => (
                      <Draggable
                        key={taskId}
                        draggableId={taskId}
                        index={index}
                      >
                        {(provided) => (
                          <div
                            className="bg-gray-50 p-2 mb-2 rounded border hover:shadow-md transition duration-200"
                            ref={provided.innerRef}
                            {...provided.draggableProps}
                            {...provided.dragHandleProps}
                          >
                            {tasks[taskId]?.content}
                          </div>
                        )}
                      </Draggable>
                    ))}
                    {provided.placeholder}
                  </div>
                )}
              </Droppable>
            </div>
          ))}
        </div>
      </DragDropContext>
    </div>
  );
};

export default App;
