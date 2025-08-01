import { useEffect, useState } from 'react';
import axios from 'axios';

type Transaction = {
  id: number;
  accountId: number;
  amount: number;
  type: string;
  createdAt: string;
};

export default function TransactionList() {
  const [transactions, setTransactions] = useState<Transaction[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    axios.get(import.meta.env.VITE_API_BASE + '/api/transactions')
      .then(res => setTransactions(res.data))
      .catch(err => setError(err.message))
      .finally(() => setLoading(false));
  }, []);

  if (loading) return <div className="p-4">Loading...</div>;
  if (error) return <div className="p-4 text-red-500">Error: {error}</div>;

  return (
    <div className="p-4">
      <h2 className="text-xl font-bold mb-4">Transactions</h2>
      <ul className="space-y-2">
        {transactions.map(t => (
          <li key={t.id} className="p-2 border rounded">
            <div><b>Type:</b> {t.type}</div>
            <div><b>Amount:</b> {t.amount}</div>
            <div><b>Account:</b> {t.accountId}</div>
            <div className="text-sm text-gray-500">{new Date(t.createdAt).toLocaleString()}</div>
          </li>
        ))}
      </ul>
    </div>
  );
}
